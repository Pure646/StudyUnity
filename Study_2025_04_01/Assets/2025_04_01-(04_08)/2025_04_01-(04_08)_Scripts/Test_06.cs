using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_06 : MonoBehaviour
{
    public char a_Day;
    //private enum c_Day
    //{
    //    월 = 1,
    //    화 = 2,
    //    수 = 3,
    //    목 = 4,
    //    금 = 5,
    //    토 = 6,
    //    일 = 7,
    //}
    private void Start()
    {
        char b_Day = '월';

        if (a_Day == '월')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '화')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '수')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '목')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '금')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '토')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else if (a_Day == '일')
            Debug.Log($"오늘은 {a_Day}요일 입니다.");
        else
            Debug.Log("해당하는 요일은 정확히 입력해 주세요.");

        switch(a_Day)
        {
            case '월':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '화':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '수':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '목':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '금':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '토':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            case '일':
                Debug.Log($"오늘은 {a_Day}요일 입니다.");
                break;
            default:
                Debug.Log("해당하는 요일은 정확히 입력해 주세요.");
                break;
        }
    }
    private void Update()
    {
        // 유니티 에디터에서 키보드 입력이 잘 안 먹힐 때 확인해 봐야할 사항
        // 1, GameView 창을 한번 클릭해 준다.
        // (유니티 에디터 GameView 창에 포커스 상태를 가게 만들기 위해...)
        // 2, 한 / 영 키가 눌려져 있는 상태에서 (한글 입력 상태는 안된다.)
        // 안되는 경우가 있을 수 있다.
        // (영문키는 영어 입력 상태에서만 정상 입력 받는다.)
        
        if(Input.GetKey(KeyCode.Space)== true)
        {
            //int a_Rand = Random.Range(1, 101);      // 1부터 100까지 랜덤한 숫자를 발생시키기
            //Debug.Log("랜덤값 : " + a_Rand);

            //int a_Dice = Random.Range(1, 7);
            //Debug.Log("주사위 랜덤값 : " + a_Dice);

            float a_FRd = Random.Range(0.0f, 10.0f);    // 0.0f ~ 10.0f 까지 랜덤한 숫자를 발생시켜 줌.
            Debug.Log(a_FRd);
        }
    }
}
