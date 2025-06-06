using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatCharacter : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 1;
    public static int CatHp;                    // 현재 체력
    public int MaxHp => maxHp;
    [SerializeField] private int maxHp;         // 최대 체력

    public GameObject GameOver_Image;
    private Button ReplayBtn;
    private Text GoldCollection_Text;
    private bool OnGameSet;
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        CatHp = MaxHp;
        OnGameSet = true;
    }
    private void Update()
    {
        if(CatHp > 0)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(characterSpeed * Time.deltaTime * -1f, 0, 0);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(characterSpeed * Time.deltaTime, 0, 0);
            }
            RemitCharacter();
        }
        else if(CatHp <= 0 && OnGameSet)      // GameOver
        {
            OnGameSet = false;
            GameOver_Image.SetActive(true);
            ReplayBtn = GameObject.Find("ReplayBtn").GetComponent<Button>();
            ReplayBtn.onClick.AddListener(() => Replay_Btn());
            GoldCollection_Text = GameObject.Find("GoldCollection_Text").GetComponent<Text>();
            GoldCollection_Text.text = $"Gold : {DropArrow.Gold}";
        }
    }
    private void RemitCharacter()
    {
        Vector2 characterVec = transform.position;
        if (characterVec.x <= -8.5)
        {
            characterVec.x = -8.5f;
        }
        else if (characterVec.x >= 8.5)
        {
            characterVec.x = 8.5f;
        }
        transform.position = characterVec;
    }

    private void Replay_Btn()
    {
        SceneManager.LoadScene("Academy_assignment CatEscape");
    }

    public void Lbtn()
    {
        transform.Translate(characterSpeed * Time.deltaTime * -1f, 0, 0);
    }
    public void RBtn()
    {
        transform.Translate(characterSpeed * Time.deltaTime, 0, 0);
    }
}
