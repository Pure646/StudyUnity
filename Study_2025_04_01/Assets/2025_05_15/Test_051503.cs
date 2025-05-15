using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 클래스 소속 맴법 static(정적) 변수, (정적메서드)
// <특정>
// 1, 객체 생성없이 클래스이름.변수면, 클래스이름.메서드이름()
// 2, 프로그램이 시작할 때 메모리가 확보되서 프로그램이 종료될 때까지 유지된다.
// 3, 클래스 소속이지만 메모리를 클래스와 별도로 생성하고 공유된다.

public class Hero
{
    public string m_Name;                   //<-- 일반 맴버 변수 (인스턴스 맴버 변수)
    public int m_Hp;

    public static int s_UserPoint = 0;      //<-- 정적 맴버 변수 (클래스 맴버 변수)

    public void AddUserPoint(int a_Point)   //<-- 일반 맴버 메서드 (인스턴스 맴버 메서드)
    {
        s_UserPoint = a_Point;
    }
    public int GetUserPoint()               //<-- 일반 맴버 메서드
    {
        return s_UserPoint;
    }

    public static void StaticPrint()        //<-- 정적 맴버 메서드 (클래스 맴버 메서드)
    {
        Debug.Log(s_UserPoint);
    }
}
public class Test_051503 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
