using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    UserPlay_Ing = 0,       // 게임 진행 상태
    Result_Ing = 1,         // 선택 결과를 보여주는 상태
    GameEnd = 2,            // 게임 종료 상태
}
public enum GBB
{
    None = 0,
    Gawi = 1,       // 가위
    Bawi = 2,       // 바위
    Bo = 3,         // 보
}
public enum Record
{
    Draw = 0,       // 비겼다
    Win = 1,        // 이겼다
    Lost = 2,       // 졌다
}
public class Game_mgr_3 : MonoBehaviour
{
    private GameState m_GameState = GameState.UserPlay_Ing;     // 유저가 선택을 고민하는 상태
    float m_CacAnim = 0.0f;         // 컴퓨터 손 이미지 애니메시연 연출용 변수

    public Button Gawi_Btn;
    public Button Bawi_Btn;
    public Button Bo_Btn;
    public Button Replay_Btn;

    public Text UserInfo_Text;
    public Text Result_Text;

    private int m_Money = 1000;
    private int m_WinCount = 0;
    private int m_LostCount = 0;

    private GBB NumGBB;

    [Header("--- Direction Image ---")]
    public Image UserGBB_Img;
    public Image ComGBB_Img;

    public Sprite[] GBB_Sprite;     // 가위, 바위 , 보 스프라이트를 연결할 배열 변수
    public Text ShowResult_Text;    // 게임 결과 큰 글씨

    private float m_WaitTimer = 0.0f;

    private void Start()
    {
        if(Gawi_Btn != null)
        {
            Gawi_Btn.onClick.AddListener(() =>
            {
                BtnClickMethod(GBB.Gawi);
            });
        }
        if(Bawi_Btn != null)
        {
            Bawi_Btn.onClick.AddListener(() =>
            {
                BtnClickMethod(GBB.Bawi);
            });
        }
        if(Bo_Btn!= null)
        {
            Bo_Btn.onClick.AddListener(()=>
            {
                BtnClickMethod(GBB.Bo);
            });
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

        ComGBB_Img.gameObject.SetActive(true);
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

        if (m_GameState == GameState.UserPlay_Ing)
        {
            m_CacAnim += (Time.deltaTime * 50.0f);
            if(3.0f <= m_CacAnim)
            {
                m_CacAnim = 0.0f;
            }
            int a_AIdx = (int)m_CacAnim;
            if (0 <= a_AIdx && a_AIdx < GBB_Sprite.Length) 
            {
                ComGBB_Img.sprite = GBB_Sprite[a_AIdx];
            }
        }
        else if(m_GameState == GameState.Result_Ing)
        {
            if(0.0f < m_WaitTimer)
            {
                m_GameState = GameState.UserPlay_Ing;
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

    private void BtnClickMethod(GBB a_UserSel)
    {
        if (m_Money <= 0)
            return;

        GBB a_ComSel = (GBB)Random.Range((int)GBB.Gawi, (int)GBB.Bo + 1);
        string a_strUser = "가위";
        if (a_UserSel == GBB.Bawi)
            a_strUser = "바위";
        else if (a_UserSel == GBB.Bo)
            a_strUser = "보";

        string a_strCom = "가위";
        if (a_ComSel == GBB.Bawi)
            a_strCom = "바위";
        else if (a_ComSel == GBB.Bo)
            a_strCom = "보";

        Result_Text.text = "User(" + a_strUser + ") : Com(" + a_strCom + ")";

        //--- 판정
        Record a_IsWin = Record.Draw;
        if (a_UserSel == a_ComSel)
        {
            Result_Text.text += " 비겼습니다.";
            a_IsWin = Record.Draw;
        }
        else if
            ((a_UserSel == GBB.Gawi && a_ComSel == GBB.Bo) ||
            (a_UserSel == GBB.Bawi && a_ComSel == GBB.Gawi) ||
            (a_UserSel == GBB.Bo && a_ComSel == GBB.Bawi))
        {
            Result_Text.text += " 이겼습니다.";
            a_IsWin = Record.Win;
        }
        else
        {
            Result_Text.text += " 졌습니다.";
            a_IsWin = Record.Lost;
        }
        if(a_IsWin >= 0)
        {
            if(a_IsWin == Record.Win)
            {
                ShowResult_Text.text = "승리!!";
                ShowResult_Text.color = Color.cyan;
            }
            else if (a_IsWin == Record.Lost)
            {
                ShowResult_Text.text = "패배!!";
                ShowResult_Text.color = Color.red;
            }
            else
            {
                ShowResult_Text.text = "무승부";
                ShowResult_Text.color = Color.white;
            }

            ShowResult_Text.gameObject.SetActive(true);
        }


        ComGBB_Img.sprite = GBB_Sprite[(int)a_ComSel - 1];

        UserGBB_Img.gameObject.SetActive(true);
        UserGBB_Img.sprite = GBB_Sprite[(int)a_UserSel - 1];

        if (a_IsWin == Record.Win)
        {
            m_WinCount++;
            m_Money += 100;
        }
        else if (a_IsWin == Record.Lost)
        {
            m_LostCount++;
            m_Money -= 200;
            if (m_Money <= 0)
            {
                m_Money = 0;
                Result_Text.text = "Game Over";
            }
        }

        m_GameState = GameState.Result_Ing;         //<-- 게임 결과를 3초 동안 보여주는 상태로 변경
        m_WaitTimer = 3.0f;                         // 타이머 설정

        if (m_Money <= 0)
            m_GameState = GameState.GameEnd;
    }
}
