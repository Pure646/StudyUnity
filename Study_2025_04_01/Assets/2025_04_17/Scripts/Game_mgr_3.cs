using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GBB
{
    Gawi = 1,       // ����
    Bawi = 2,       // ����
    Bo = 3,         // ��
}
public enum Record
{
    Draw = 0,       // ����
    Win = 1,        // �̰��
    Lost = 2,       // ����
}
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
                () =>       // ������ ���� ������ ���ٽ��� �̿��Ѵ�.        // ���ٽ� : �����Լ�
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
            UserInfo_Text.text = "������ �����ݾ� : " + m_Money +
                " : �� (" + m_WinCount + ")" +
                " : �� (" + m_LostCount + ")";
        }
    }

    private void ReplayBtnClick()
    {
        Debug.Log("���÷��� ��ư");
        m_Money = 10000;
        m_LostCount = 0;
        m_WinCount = 0;
    }

    private void BtnClickMethod(GBB a_UserSel)
    {
        if (m_Money <= 0)
            return;

        GBB a_ComSel = (GBB)Random.Range((int)GBB.Gawi, (int)GBB.Bo + 1);
        string a_strUser = "����";
        if (a_UserSel == GBB.Bawi)
            a_strUser = "����";
        else if (a_UserSel == GBB.Bo)
            a_strUser = "��";

        string a_strCom = "����";
        if (a_ComSel == GBB.Bawi)
            a_strCom = "����";
        else if (a_ComSel == GBB.Bo)
            a_strCom = "��";

        Result_Text.text = "User(" + a_strUser + ") : Com(" + a_strCom + ")";

        //--- ����
        Record a_IsWin = Record.Draw;
        if (a_UserSel == a_ComSel)
        {
            Result_Text.text += " �����ϴ�.";
            a_IsWin = Record.Draw;
        }
        else if
            ((a_UserSel == GBB.Gawi && a_ComSel == GBB.Bo) ||
            (a_UserSel == GBB.Bawi && a_ComSel == GBB.Gawi) ||
            (a_UserSel == GBB.Bo && a_ComSel == GBB.Bawi))
        {
            Result_Text.text += " �̰���ϴ�.";
            a_IsWin = Record.Win;
        }
        else
        {
            Result_Text.text += " �����ϴ�.";
            a_IsWin = Record.Lost;
        }
        if(a_IsWin >= 0)
        {
            if(a_IsWin == Record.Win)
            {
                ShowResult_Text.text = "�¸�!!";
                ShowResult_Text.color = Color.cyan;
            }
            else if (a_IsWin == Record.Lost)
            {
                ShowResult_Text.text = "�й�!!";
                ShowResult_Text.color = Color.red;
            }
            else
            {
                ShowResult_Text.text = "���º�";
                ShowResult_Text.color = Color.white;
            }

            ShowResult_Text.gameObject.SetActive(true);
        }
        if (a_ComSel > 0)
        {
            ComGBB_Img.gameObject.SetActive(true);

            if (a_ComSel == GBB.Gawi)
            {
                ComGBB_Img.sprite = GawiSprite;
            }
            else if (a_ComSel == GBB.Bawi)
            {
                ComGBB_Img.sprite = BawiSprite;
            }
            else if (a_ComSel == GBB.Bo)
            {
                ComGBB_Img.sprite = BoSprite;
            }
        }
        if (a_UserSel > 0)
        {
            if (a_UserSel == GBB.Gawi)
            {
                UserGBB_Img.sprite = GawiSprite;
            }
            else if (a_UserSel == GBB.Bawi)
            {
                UserGBB_Img.sprite = BawiSprite;
            }
            else if (a_UserSel == GBB.Bo)
            {
                UserGBB_Img.sprite = BoSprite;
            }
            UserGBB_Img.gameObject.SetActive(true);
        }

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
    }
}
