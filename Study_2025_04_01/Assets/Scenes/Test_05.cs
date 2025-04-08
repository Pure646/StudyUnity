using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_05 : MonoBehaviour
{
    private void Start()
    {
        //switch ~case 문
        //switch (조건식) // 조건식의 결과로 나올 수 있는 값 : 정수형 , 문자 , 문자열
        //{
        //    case 상수:
        //        실행될 상수;
        //}
        int a_ii = 20;
        switch(a_ii % 2)
        {
            case 0:
                Debug.Log("짝수입니다.");
                break;
            case 1:
                Debug.Log("홀수입니다.");
                break;
        }

        if ((a_ii % 2) == 0)
            Debug.Log("짝수 입니다.");
        else if ((a_ii % 2) == 1)
            Debug.Log("홀수 입니다.");

        char a_Day = '화';       // C# char형은 2byte
        // -> 오늘은 화요일입니다.
    }
}
