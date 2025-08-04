using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    [SerializeField] private GameObject MonsterSpawn;
    [SerializeField] private Text Pointer;
    [SerializeField] private float SpawnTime;
    private float RealTime;
    public static int point;

    [SerializeField] private Image GameOver_Img;
    [SerializeField] private Text GameOverPointer;

    // ½Ì±ÛÅæ
    public static Game_Mgr Instance = null;

    [Header("DamageTxt")]
    [SerializeField] private Transform DamageCanvas = null;
    [SerializeField] private GameObject DamageTxt = null;
    private GameObject CloneTxt;
    private DamageTxt D_Txt;
    private Vector3 StCacPos;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Pointer.gameObject.SetActive(true);
        GameOver_Img.gameObject.SetActive(false);

        point = 0;
    }
    private void Update()
    {
        if(Hero_Ctrl.CharacterHp > 0)
        {
            if(RealTime > 0)
            {
                RealTime -= Time.deltaTime;
                Pointer.text = $"Á¡¼ö : {point.ToString("D3")}";
            }
            else if(RealTime <= 0)
            {
                MonsterSpawner();
                SpawnTime -= 0.001f;
                RealTime = SpawnTime;
            }
        }
        if(Hero_Ctrl.CharacterHp <= 0)
        {
            Pointer.gameObject.SetActive(false);
            GameOver_Img.gameObject.SetActive(true);
            GameOverPointer.text = $"Á¡¼ö : {point}";
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    public void DamageText(float a_Value, Vector3 a_Pos, Color a_Color)
    {
        if (DamageCanvas == null || DamageTxt == null)
            return;
        CloneTxt = Instantiate(DamageTxt);
        CloneTxt.transform.SetParent(DamageCanvas);
        D_Txt = CloneTxt.GetComponent<DamageTxt>();
        if(D_Txt != null)
        {
            D_Txt.InitDamage(a_Value, a_Color);
        }
        StCacPos = new Vector3(a_Pos.x, a_Pos.y, 0.0f);
        CloneTxt.transform.position = StCacPos;
    }
    private void MonsterSpawner()
    {
        float RandomY = Random.Range((int)CamResol.m_VpWMin.y + 1, (int)CamResol.m_VpWMax.y);
        Vector2 TransSpawn = new Vector2(CamResol.m_VpWMax.x + 1f, RandomY);
        GameObject Spawn = Instantiate(MonsterSpawn, TransSpawn, Quaternion.identity);
    }
}
