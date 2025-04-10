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
        //Debug.Log("짝수 버튼을 눌렀어요.");
        //Result_Text.text = "짝수 버튼을 눌렀어요.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "짝수";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "홀수";
        if(a_UserSel == (a_DiceNum % 2))
        {
            Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞췄습니다.";
        }
        else
        {
            Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀렸습니다.";
        }
    }
    private void OddBtnClick()
    {
        //Debug.Log("홀수 버튼 클릭");
        //Result_Text.text = "홀수 버튼을 눌렀어요.";
        int a_UserSel = 0;
        int a_DiceNum = Random.Range(1, 7);
        string a_StrCom = "홀수";
        if ((a_DiceNum % 2) == 0)
            a_StrCom = "짝수";
        if (a_UserSel == (a_DiceNum % 2))
        {
            Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀렸습니다.";
        }
        else
        {
            Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞췄습니다.";
        }
    }
    private void ReplayClick()
    {
        Debug.Log("다시하기 클릭");
    }
}
