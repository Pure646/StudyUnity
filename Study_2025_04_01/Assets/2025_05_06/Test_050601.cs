using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_050601 : MonoBehaviour
{
    // 리턴형과 매개변수에 따른 메서드의 종류
    // 1, 리턴형과 매개변수가 모두 존재하는 형태
    // 2, return형이 없고, 매개변수가 있는 형태
    // 3, return형이 없고, 매개변수가 없는 형태
    // 4, return형이 있고, 매개변수가 없는 형태

    // 1, return형과 매개변수가 모두 존재하는 형태
    public int Sum(int a, int b)
    {
        int c = a + b;
        return c;
    }
    public int MyMethod(int a, int b)
    {
        int c = a + b;      //<--- 메서드의 정의 (설계도)
        return c;
    }

    // 2, return 형이 없고, 매개변수가 있는 형태
    public void Hamsu(int Kor, int Eng, int Math)
    {   // void  : 리턴갑시 없다는 의미 (리턴값을 돌려주지 않아도 된다.

        int a_Hap = Kor + Eng + Math;
        Debug.Log("총점 : " +  a_Hap);

        if (a_Hap < 20)
            return;

        Debug.Log("평균 : " + (a_Hap / 3.0f).ToString("F2"));
    }

    // 3, return 형이 없고, 매개변수가 없는 형태
    public void PrintGuGuDan()
    {
        int a_Dan = 7;
        for (int i = 1; i < 10; i++)
        {
            Debug.Log(a_Dan + " * " + i + " = " + (a_Dan * i));
        }
    }

    // 4, return 형이 있고, 매개변수가 없는 형태
    float m_Velocity = 10.0f;       // 맴버변수
    public bool IsMove()
    {
        if(m_Velocity <= 0.0f)
        {
            return false;
        }
        return true;
    }
    private void Start()
    { // 유니티의 이벤트 함수 : 우리가 호출해 주지 않아도 유니티가 자동 호출해 주는 함수
        // 유니티 시스템이 특정 상황에 맞게 호출해 주는 함수 : 콜백함수

        // 매개변수, parameter, 인자(인수)

        int AAA = MyMethod(111, 222);       //<--- 메서드의 호출 (메서드의 사용)

        int BBB = MyMethod(12, 34);

        int CCC = MyMethod(77, 88);

        //Debug.Log(AAA + " : " + BBB + " : " + CCC);

        Sum(11, 25); //<-- 리턴형이 있는 함수여도 리턴값을 받아서 사용하지 않아도 된다.
        int ABC = Sum(11, 25) + 99;
        //Debug.Log(ABC);

        //Hamsu(50, 10, 30);
        //Hamsu(1, 2, 3);

        PrintGuGuDan();

        if(IsMove() == true)
        {
            Debug.Log("움직이고 있어");
        }
        else
        {
            Debug.Log("멈춰 있어");
        }
    }
}
