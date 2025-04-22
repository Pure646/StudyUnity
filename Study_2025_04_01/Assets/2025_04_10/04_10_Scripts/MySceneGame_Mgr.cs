using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneGame_Mgr : MonoBehaviour
{
    public Button Even_Btn;
    public Button Odd_Btn;
    public Button Replay_Btn;

    public Text UserInfo_Text;
    public Text Result_Text;
    public Text DiceRoll_Text;

    int m_Money = 1000;         // 유저의 보유 금액
    int m_WinCount = 0;         // 승리 카운트
    int m_LostCount = 0;        // 패배 카운트

    [Header("--- Character Image ---")]
    public Image CharacterImg;
    public Sprite WaitImg;
    public Sprite WinImg;
    public Sprite LostImg;
    public Image GameOverImg;

    private float m_WaitTimer = 0.0f;

    [Header("--- NickName ---")]
    public InputField NickInputField;
    public Button InputBtn;
    string m_NickName = "User";


    private void Start()
    {
        if(Even_Btn != null)        // 변수에 버튼 UI가 잘 연결 되어 있으면...
        {   
            Even_Btn.onClick.AddListener(EvenBtnClick);     // 버튼을 누르면 반응하는 함수 대기 시켜놓기
        }
        if (Odd_Btn != null)
        {
            Odd_Btn.onClick.AddListener(OddBtnClick);
        }
        if ((Replay_Btn != null))
        {
            Replay_Btn.onClick.AddListener(ReplayClick);
        }
        if(GameOverImg != null)
        {
            GameOverImg.gameObject.SetActive(false);
        }
        if(CharacterImg != null)
        {
            CharacterImg.gameObject.SetActive(true);
        }
        if(InputBtn != null)
        {
            InputBtn.onClick.AddListener(InputBtnClick);
        }
    }
    private int DiceRoll;
    private void Update()
    {
        if (m_Money <= 0)
            return;
        if(0.0f < m_WaitTimer)
        {
            m_WaitTimer -= Time.deltaTime;      // Time.deltaTime : 한 프레임이 도는데 걸리는 시간
            if(m_WaitTimer <= 0.0f)
            {
                CharacterImg.sprite = WaitImg;
            }
        }
        DiceRoll = Random.Range(1, 7);
        DiceRoll_Text.text = $"[ {DiceRoll} ] + [ {DiceRoll} ] = [ {DiceRoll * 2} ]";
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(DiceRoll);
        }
        if(Input.GetKey(KeyCode.V))
        {
            Even_Btn.onClick.Invoke();
            if(m_Money <= 0)
            {
                UserInfo_Text.text = m_NickName + "의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
            }
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            m_Money = 1000;
            UserInfo_Text.text = m_NickName + "의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
            CharacterImg.gameObject.SetActive(true);
            GameOverImg.gameObject.SetActive(false);
        }
    }
    private void InputBtnClick()
    {
        if (m_Money <= 0)
            return;

        string a_Nick = NickInputField.text;
        if (a_Nick == "")
            m_NickName = "User";
        else
            m_NickName = a_Nick;

        //--- 유저 정보 UI 갱신
        UserInfo_Text.text = m_NickName + "의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
    }
    private void EvenBtnClick()
    {
        if (m_Money <= 0)
            return;             // 즉시 함수를 빠져 나가는 명령어
        //Debug.Log("짝수 버튼을 눌렀어요.");
        //Result_Text.text = "짝수 버튼을 눌렀어요.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "짝수";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "홀수";
        if(m_Money > 0)
        {
            if(a_UserSel == (a_DiceNum % 2))
            {
                Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞췄습니다.";

                m_WinCount++;
                m_Money += 100;

                CharacterImg.sprite = WinImg;
            }
            else
            {
                Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀렸습니다.";

                m_LostCount++;
                m_Money -= 200;

                CharacterImg.sprite = LostImg;
            }
            // 판정

            // 유저 정보 UI 갱신
            UserInfo_Text.text = m_NickName + "의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
            // 유저 정보 UI 갱신
            m_WaitTimer = 5.0f;
        }
        if (m_Money <= 0)
        {
            m_Money = 0;
            Result_Text.text = "Game Over";
            CharacterImg.gameObject.SetActive(false);
            GameOverImg.gameObject.SetActive(true);
        }
    }
    private void OddBtnClick()
    {
        if (m_Money <= 0)
            return;     
        //Debug.Log("홀수 버튼 클릭");
        //Result_Text.text = "홀수 버튼을 눌렀어요.";
        int a_UserSel = 1;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "짝수";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "홀수";
        if (m_Money > 0)
        {
            if (a_UserSel == (a_DiceNum % 2))
            {
                Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞췄습니다.";

                m_WinCount++;
                m_Money += 200;

                CharacterImg.sprite = WinImg;
            }
            else
            {
                Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀렸습니다.";

                m_LostCount++;
                m_Money -= 00;

                CharacterImg.sprite = LostImg;
            }
            // 유저 정보 UI 갱신
            UserInfo_Text.text = m_NickName + "의 보유금액 : " + m_Money +
                " : 승 (" + m_WinCount + ")" +
                " : 패 (" + m_LostCount + ")";
            m_WaitTimer = 5.0f;
        }
        if (m_Money <= 0)
        {
            m_Money = 0;
            Result_Text.text = "Game Over";
            CharacterImg.gameObject.SetActive(false);
            GameOverImg.gameObject.SetActive(true);
        }
    }
    private void ReplayClick()
    {
        //Debug.Log("다시하기 클릭");
        //m_Money = 1000;
        //m_WinCount = 0;
        //m_LostCount = 0;

        //UserInfo_Text.text = "유저의 보유금액 : " + m_Money +
        //        " : 승 (" + m_WinCount + ")" +
        //        " : 패 (" + m_LostCount + ")";

        SceneManager.LoadScene("2025_04_10_GameScene");
    }
    private void OnDestroy()
    {
        Debug.Log("HI");
    }
}
