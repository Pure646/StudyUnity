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

    [Header("--- Direction Image ---")]
    public Image UserGBB_Img;
    public Image ComGBB_Img;

    public Sprite GawiSprite;
    public Sprite BawiSprite;
    public Sprite BoSprite;

    public Text ShowResult_Text;

    private float m_WaitTimer = 0.0f;

    private int time = 1;
    private float m_Time = 0.0f;
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
            Replay_Btn.onClick.AddListener(
                () =>       // 내용이 많지 않으면 람다식을 이용한다.        // 람다식 : 무명함수
            {
                m_Money = 10000;
                m_LostCount = 0;
                m_WinCount = 0;
            }
            );
        }
    }
    private void Update()
    {
        if(m_Money <= 0)
        {
            m_Money = 0;
            Result_Text.text = "Game Over";
        }

        if(UserInfo_Text != null)
        {
            UserInfo_Text.text = "유저의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
        }
        if (Time.time >= m_Time && m_Money > 0)
        {
            m_Time += 0.01f;
            BoBtnClick();
        }
        
        if(0.0f < m_WaitTimer)
        {
            m_WaitTimer -= Time.deltaTime;
            if(m_WaitTimer <= 0.0f)
            {
                UserGBB_Img.gameObject.SetActive(false);
                ComGBB_Img.gameObject.SetActive(false);
                ShowResult_Text.gameObject.SetActive(false);

                Result_Text.color = Color.yellow;
                Result_Text.text = "선택해 주세요.";
            }
        }
        
    }

    private void ReplayBtnClick()
    {
        Debug.Log("리플레이 버튼");
        m_Money = 10000;
        m_LostCount = 0;
        m_WinCount = 0;
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

            ShowResult_Text.color = new Color32(255, 255, 0, 255);
            ShowResult_Text.text = "무승부";
        }
        else if ((a_UserSel == 3 && a_ComSel == 2))
        {
            a_strResult += " = 이겼습니다.";
            m_WinCount++;
            m_Money += 100;

            ShowResult_Text.color = new Color32(0, 0, 0, 255);
            ShowResult_Text.text = "승리!!";
        }
        else
        {
            a_strResult += " = 졌습니다.";
            m_LostCount++;
            m_Money -= 150;

            ShowResult_Text.color = new Color32(255, 0, 0, 255);
            ShowResult_Text.text = "패배!!";
        }

        Result_Text.text = a_strResult;

        UserGBB_Img.sprite = BoSprite;
        if(UserGBB_Img.gameObject.activeSelf == false)
        {
            UserGBB_Img.gameObject.SetActive(true);
        }
        if (ComGBB_Img.gameObject.activeSelf == false)
        {
            ComGBB_Img.gameObject.SetActive(true);
        }
        if(ShowResult_Text.gameObject.activeSelf == false)
        {
            ShowResult_Text.gameObject.SetActive(true);
        }
        if (a_ComSel == 1)
        {
            ComGBB_Img.sprite = GawiSprite;
        }
        else if(a_ComSel == 2)
        {
            ComGBB_Img.sprite = BawiSprite;
        }
        else if(a_ComSel == 3)
        {
            ComGBB_Img.sprite = BoSprite;
        }
        m_WaitTimer = 3.0f;
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

            ShowResult_Text.color = new Color32(255, 255, 0, 255);
            ShowResult_Text.text = "무승부";
        }
        else if ((a_UserSel == 2 && a_ComSel == 1))
        {
            a_strResult += " = 이겼습니다.";
            m_WinCount++;
            m_Money += 100;

            ShowResult_Text.color = new Color32(0, 0, 0, 255);
            ShowResult_Text.text = "승리!!";
        }
        else
        {
            a_strResult += " = 졌습니다.";
            m_LostCount++;
            m_Money -= 150;

            ShowResult_Text.color = new Color32(255, 0, 0, 255);
            ShowResult_Text.text = "패배!!";
        }

        Result_Text.text = a_strResult;

        UserGBB_Img.sprite = BawiSprite;
        if (UserGBB_Img.gameObject.activeSelf == false)
        {
            UserGBB_Img.gameObject.SetActive(true);
        }
        if(ComGBB_Img.gameObject.activeSelf == false)
        {
            ComGBB_Img.gameObject.SetActive(true);
        }
        if (ShowResult_Text.gameObject.activeSelf == false)
        {
            ShowResult_Text.gameObject.SetActive(true);
        }
        if (a_ComSel == 1)
        {
            ComGBB_Img.sprite = GawiSprite;
        }
        else if (a_ComSel == 2)
        {
            ComGBB_Img.sprite = BawiSprite;
        }
        else if (a_ComSel == 3)
        {
            ComGBB_Img.sprite = BoSprite;
        }
        m_WaitTimer = 3.0f;
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

            ShowResult_Text.color = new Color32(255, 255, 0, 255);
            ShowResult_Text.text = "무승부";
        }
        else if ((a_UserSel == 1 && a_ComSel == 3))
        {
            a_strResult += " = 이겼습니다.";
            m_WinCount++;
            m_Money += 100;

            ShowResult_Text.color = new Color32(0, 0, 0, 255);
            ShowResult_Text.text = "승리!!";
        }
        else
        {
            a_strResult += " = 졌습니다.";
            m_LostCount++;
            m_Money -= 150;

            ShowResult_Text.color = new Color32(255, 0, 0, 255);
            ShowResult_Text.text = "패배!!";
        }

        Result_Text.text = a_strResult;

        UserGBB_Img.sprite = GawiSprite;
        if (UserGBB_Img.gameObject.activeSelf == false)
        {
            UserGBB_Img.gameObject.SetActive(true);
        }
        if (ComGBB_Img.gameObject.activeSelf == false)
        {
            ComGBB_Img.gameObject.SetActive(true);
        }
        if (ShowResult_Text.gameObject.activeSelf == false)
        {
            ShowResult_Text.gameObject.SetActive(true);
        }
        if (a_ComSel == 1)
        {
            ComGBB_Img.sprite = GawiSprite;
        }
        else if (a_ComSel == 2)
        {
            ComGBB_Img.sprite = BawiSprite;
        }
        else if (a_ComSel == 3)
        {
            ComGBB_Img.sprite = BoSprite;
        }
        m_WaitTimer = 3.0f;
    }
}
