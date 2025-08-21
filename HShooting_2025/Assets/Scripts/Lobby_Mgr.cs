using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby_Mgr : MonoBehaviour
{
    public Button Store_Btn;
    public Button MyRoom_Btn;
    public Button Exit_Btn;
    public Button GameStart_Btn;

    public Text m_GoldText;
    public Text m_UserInfoText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        GlobalValue.LoadGameData();

        if(Store_Btn != null)
            Store_Btn.onClick.AddListener(StoreBtnClick);

        if(MyRoom_Btn != null)
            MyRoom_Btn.onClick.AddListener(MyRoomBtnClick);

        if(Exit_Btn != null)
            Exit_Btn.onClick.AddListener(ExitBtnClick);

        if (GameStart_Btn != null)
            GameStart_Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });
        if (m_GoldText != null)
            m_GoldText.text = GlobalValue.g_UserGold.ToString("N0");

        if (m_UserInfoText != null)
            m_UserInfoText.text = "내정보 : 별명(" + GlobalValue.g_NickName +
                ") : 점수(" + GlobalValue.g_BestScore + ")";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StoreBtnClick()
    {
        //Debug.Log("상점씬으로 이동");
        SceneManager.LoadScene("StoreScene");
    }

    void MyRoomBtnClick()
    {
        //Debug.Log("꾸미기씬으로 이동");
        SceneManager.LoadScene("MyRoomScene");
    }

    void ExitBtnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
