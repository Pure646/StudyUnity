using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메서드의 오버로딩 (함수의 오버로딩)
// 하나의 메서드 이름으로 여러개의 메서드를 구현하는 것
// 매개변수의 형식만 다르면 같은 메서드 이름을 사용할 수 있다.
// 기본용도 : 하나의 함수 이름으로 다양한 데이터형 매개변수를 편하게 사용하기 위해서 사용되는 문법

public class Test_050801 : MonoBehaviour
{
    int Plus(int a, int b)
    {
        return a + b;
    }
    //int Plus(int c, int d)        //<-- 매개변수의 형식이 같은 메서드 이름이 이미 정의 되어 있어서 에러난다.
    //{
    //    return c + d;
    //}

    int Plus(float a, float b)      //<-- 메서드의 오버로드 or 오버로딩 예
    {
        return (int)(a * b);
    }

    int Plus(int c)                 //<-- 메서드의 오버로드 or 오버로딩 예
    {
        return c;
    }

    double Plus(double a, double b) //<-- 메서드의 오버로드 or 오버로딩 예
    {
        Debug.Log("double + double");
        return a + b;
    }

    //double Plus(int c, int d)     //<-- 매개변수의 형식이 같은 메서드 이름이 이미 정의 되어 있어서 에러난다.
    //{
    //    return c + d;
    //}

    double Plus(int c, float d)     //<-- 메서드의 오버로드 or 오버로딩 예
    {
        return c + d;
    }

    private void Start()
    {
        Debug.Log(Plus(45, 70));
        Debug.Log(Plus(1.0f, 2.4f));
        Debug.Log(Plus(85));
        Debug.Log(Plus(3.5, 4.2));

        // 유니티 C#에서 지원하는 메서드 오버로드의 예
        int iRand = Random.Range(1, 7);
        float fRand = Random.Range(1.5f, 3.14f);

        int AAA = 4;
        AAA = Mathf.Clamp(AAA, 0, 10);          // 0 <= AAA <= 10 일 때   , 출력 : AAA      
                                                // 0 > AAA 일 때          , 출력 : 0
                                                // 10 < AAA 일 때         , 출력 : 10
        Debug.Log(AAA);


        float BBB = 3.14f;
        BBB = Mathf.Clamp(BBB, -1f, 1f);
        Debug.Log(BBB);
    }
}
