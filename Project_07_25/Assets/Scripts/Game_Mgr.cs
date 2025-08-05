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
    public static int point = 0;

    [SerializeField] private Image GameOver_Img;
    [SerializeField] private Text GameOverPointer;
    private void Start()
    {
        Pointer.gameObject.SetActive(true);
        GameOver_Img.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Hero_Ctrl.CharacterHp > 0)
        {
            if(RealTime > 0)
            {
                RealTime -= Time.deltaTime;
                Pointer.text = $"점수 : {point.ToString("D3")}";
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
            GameOverPointer.text = $"점수 : {point}";
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    private void MonsterSpawner()
    {
        float RandomY = Random.Range((int)CamResol.m_VpWMin.y + 1, (int)CamResol.m_VpWMax.y);
        Vector2 TransSpawn = new Vector2(CamResol.m_VpWMax.x + 1f, RandomY);
        GameObject Spawn = Instantiate(MonsterSpawn, TransSpawn, Quaternion.identity);
        //if(CamResol.m_VpWMax.x)
    }
}
