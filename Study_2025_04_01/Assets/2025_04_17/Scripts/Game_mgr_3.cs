using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_mgr_3 : MonoBehaviour
{
    public Button Gawi_Btn;
    public Button Bawi_Btn;
    public Button Bo_Btn;
    public Button Replay_Btn;

    public Text UserInfo_Text;
    public Text Result_Text;

    private int m_Money = 1000;
    private int m_WinCount = 0;
    private int m_LostCount = 0;

    private void Start()
    {
        if(Gawi_Btn != null)
        {
            Gawi_Btn.onClick.AddListener(GawiBtnClick);
        }
        if(Bawi_Btn != null)
        {
            Bawi_Btn.onClick.AddListener(BawiBtnClick);
        }
        if(Bo_Btn!= null)
        {
            Bo_Btn.onClick.AddListener(BoBtnClick);
        }
        if(Replay_Btn != null)
        {
            Replay_Btn.onClick.AddListener(ReplayBtnClick);
        }
    }

    private void ReplayBtnClick()
    {
        Debug.Log("리플레이 버튼");
    }

    private void BoBtnClick()
    {
        Debug.Log("보 버튼");

        int a_UserSel = 3;
        int a_ComSel = Random.Range(1, 4);

        string a_strUser = "보";
        string a_strCom = "가위";
        if (a_ComSel == 2)
            a_strCom = "바위";
        else if (a_ComSel == 3)
            a_strCom = "보";

        string a_strResult = "User (" + a_strUser + ") : Com (" + a_strCom + ")";
        if (a_UserSel == a_ComSel)
        {
            a_strResult += " = 비겼습니다.";
        }
        else if ((a_UserSel == 3 && a_ComSel == 2))
        {
            a_strResult += " = 이겼습니다.";
        }
        else
        {
            a_strResult += " = 졌습니다.";
        }

        Result_Text.text = a_strResult;
    }

    private void BawiBtnClick()
    {
        Debug.Log("바위 버튼");

        int a_UserSel = 2;
        int a_ComSel = Random.Range(1, 4);

        string a_strUser = "바위";
        string a_strCom = "가위";
        if (a_ComSel == 2)
            a_strCom = "바위";
        else if (a_ComSel == 3)
            a_strCom = "보";

        string a_strResult = "User (" + a_strUser + ") : Com (" + a_strCom + ")";
        if (a_UserSel == a_ComSel)
        {
            a_strResult += " = 비겼습니다.";
        }
        else if ((a_UserSel == 2 && a_ComSel == 1))
        {
            a_strResult += " = 이겼습니다.";
        }
        else
        {
            a_strResult += " = 졌습니다.";
        }

        Result_Text.text = a_strResult;
    }
    private void GawiBtnClick()
    {
        Debug.Log("가위 버튼");

        int a_UserSel = 1;
        int a_ComSel = Random.Range(1, 4);

        string a_strUser = "가위";
        string a_strCom = "가위";
        if (a_ComSel == 2)
            a_strCom = "바위";
        else if (a_ComSel == 3)
            a_strCom = "보";

        string a_strResult = "User (" + a_strUser + ") : Com (" + a_strCom + ")";
        if(a_UserSel == a_ComSel)
        {
            a_strResult += " = 비겼습니다.";
        }
        else if ((a_UserSel == 1 && a_ComSel == 3))
        {
            a_strResult += " = 이겼습니다.";
        }
        else
        {
            a_strResult += " = 졌습니다.";
        }

        Result_Text.text = a_strResult;
    }
}
