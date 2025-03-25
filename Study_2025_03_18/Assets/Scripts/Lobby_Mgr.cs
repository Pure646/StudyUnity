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
    public Button Start_btn;

    // Start is called before the first frame update
    void Start()
    {
        if(Store_Btn != null)
        {
            Store_Btn.onClick.AddListener(StoreBtnClick);
        }
        if(MyRoom_Btn != null)
        {
            MyRoom_Btn.onClick.AddListener(MyRoomBtnClick);
        }
        if(Exit_Btn != null)
        {
            Exit_Btn.onClick.AddListener(ExitBtnClick);
        }
        if(Start_btn != null)
        {
            Start_btn.onClick.AddListener(StartBtnClick);
        }
    }
    private void StartBtnClick()
    {
        Debug.Log("게임씬으로 이동");
        SceneManager.LoadScene("GameScene");
    }

    private void StoreBtnClick()
    {
        Debug.Log("상점씬으로 이동");
        SceneManager.LoadScene("ShopScene");
    }

    private void MyRoomBtnClick()
    {
        Debug.Log("꾸미기씬으로 이동");
        SceneManager.LoadScene("MyRoomScene");
    }

    private void ExitBtnClick()
    {
        Debug.Log("타이틀 씬으로 이동");
        SceneManager.LoadScene("TitleScene");
    }
}
