using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    public Button Even_Btn;
    public Button Odd_Btn;
    public Button Replay_Btn;

    public Text UserInfo_Text;
    public Text Result_Text;
    public Text DiceRoll_Text;

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
        //if (UserInfo_Text != null)
        //{
            
        //}
        //if(Result_Text != null)
        //{

        //}
    }
    private int DiceRoll;
    private void Update()
    {
        DiceRoll = Random.Range(1, 7);
        DiceRoll_Text.text = $"[ {DiceRoll} ] + [ {DiceRoll} ] = [ {DiceRoll * 2} ]";
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(DiceRoll);
        }
    }
    private void EvenBtnClick()
    {
        //Debug.Log("¦�� ��ư�� �������.");
        //Result_Text.text = "¦�� ��ư�� �������.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "¦��";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "Ȧ��";
        if(a_UserSel == (a_DiceNum % 2))
        {
            Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") ������ϴ�.";
        }
        else
        {
            Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") Ʋ�Ƚ��ϴ�.";
        }
    }
    private void OddBtnClick()
    {
        //Debug.Log("Ȧ�� ��ư Ŭ��");
        //Result_Text.text = "Ȧ�� ��ư�� �������.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "Ȧ��";
        if ((a_DiceNum % 2) == 0)
            a_StrCom = "¦��";
        if (a_UserSel == (a_DiceNum % 2))
        {
            Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") Ʋ�Ƚ��ϴ�.";
        }
        else
        {
            Result_Text.text = "�ֻ��� ���� (" + a_DiceNum + ") (" + a_StrCom + ") ������ϴ�.";
        }
    }
    private void ReplayClick()
    {
        Debug.Log("�ٽ��ϱ� Ŭ��");
    }
}
