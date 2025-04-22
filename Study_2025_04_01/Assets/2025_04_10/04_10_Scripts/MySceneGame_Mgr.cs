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

    int m_Money = 1000;         // ������ ���� �ݾ�
    int m_WinCount = 0;         // �¸� ī��Ʈ
    int m_LostCount = 0;        // �й� ī��Ʈ

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
        if(Even_Btn != null)        // ������ ��ư UI�� �� ���� �Ǿ� ������...
        {   
            Even_Btn.onClick.AddListener(EvenBtnClick);     // ��ư�� ������ �����ϴ� �Լ� ��� ���ѳ���
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
            m_WaitTimer -= Time.deltaTime;      // Time.deltaTime : �� �������� ���µ� �ɸ��� �ð�
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
                UserInfo_Text.text = m_NickName + "�� �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
            }
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            m_Money = 1000;
            UserInfo_Text.text = m_NickName + "�� �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
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

        //--- ���� ���� UI ����
        UserInfo_Text.text = m_NickName + "�� �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
    }
    private void EvenBtnClick()
    {
        if (m_Money <= 0)
            return;             // ��� �Լ��� ���� ������ ��ɾ�
        //Debug.Log("¦�� ��ư�� �������.");
        //Result_Text.text = "¦�� ��ư�� �������.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "¦��";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "Ȧ��";
        if(m_Money > 0)
        {
            if(a_UserSel == (a_DiceNum % 2))
            {
                Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") ������ϴ�.";

                m_WinCount++;
                m_Money += 100;

                CharacterImg.sprite = WinImg;
            }
            else
            {
                Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") Ʋ�Ƚ��ϴ�.";

                m_LostCount++;
                m_Money -= 200;

                CharacterImg.sprite = LostImg;
            }
            // ����

            // ���� ���� UI ����
            UserInfo_Text.text = m_NickName + "�� �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
            // ���� ���� UI ����
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
        //Debug.Log("Ȧ�� ��ư Ŭ��");
        //Result_Text.text = "Ȧ�� ��ư�� �������.";
        int a_UserSel = 1;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "¦��";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "Ȧ��";
        if (m_Money > 0)
        {
            if (a_UserSel == (a_DiceNum % 2))
            {
                Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") ������ϴ�.";

                m_WinCount++;
                m_Money += 200;

                CharacterImg.sprite = WinImg;
            }
            else
            {
                Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") Ʋ�Ƚ��ϴ�.";

                m_LostCount++;
                m_Money -= 00;

                CharacterImg.sprite = LostImg;
            }
            // ���� ���� UI ����
            UserInfo_Text.text = m_NickName + "�� �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
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
        //Debug.Log("�ٽ��ϱ� Ŭ��");
        //m_Money = 1000;
        //m_WinCount = 0;
        //m_LostCount = 0;

        //UserInfo_Text.text = "������ �����ݾ� : " + m_Money +
        //        " : �� (" + m_WinCount + ")" +
        //        " : �� (" + m_LostCount + ")";

        SceneManager.LoadScene("2025_04_10_GameScene");
    }
    private void OnDestroy()
    {
        Debug.Log("HI");
    }
}
