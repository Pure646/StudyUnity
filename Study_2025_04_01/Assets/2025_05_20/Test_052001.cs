using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 클래스 소속 맴버 static(정적) 변수 , (정적메서드)
// <특징>
// 1, 객체 생성없이 클래스이름.변수명, 클래스이름.메서드명()
// 2, 프로그램이 시작할 때 메모리가 확보되서 프로그램이 종료될 때까지 유지된다.         //Scene이 바뀌어도 바뀌지도 않고 유지된다.
// 3, 클래스 소속이지만 메모리를 클래스와 별도로 생성하고 공유된다.
// (프로그램 종료될 때 까지 영구 유지된다.)

// static은 따로 클로벌하게 사용된다.
public class Heros //<-객체
{
    public string m_Name;   //<-- 일반 맴버 변수 (인스턴스 맴버 변수)
    public int m_Hp;

    public static int s_UserPoint = 0;      //<-- 정적 맴버 변수 (클래스 맴버 변수)

    public void AddUserPoint(int a_Point)   //<-- 일반 맴버 메서드 (인스턴스 맴버 메서드)
    {
        s_UserPoint += a_Point;
    }
    public int GetUserPoint()               //<-- 일반 맴버 메서드
    {
        return s_UserPoint;
    }

    public static void StaticPrint()        //<-- 정적 맴버 메서드 (클래스 맴버 메서드)
    {
        ////Heros man = new Heros();       // <-- 일반 맴버 변수를 사용하기 위해서 필요하다.
        //m_name = "팔라독";               // <-- 일반 맴버 변수 사용은 에러난다.
        //man.m_Hp = 34;

        // 유니티에서 제공해 주는 static method 예
        Debug.Log("Test");
        int AABB = Random.Range(1, 3);
        Vector3 a_Vec = Vector3.zero;        // Vector3 : 구조체
        //class 는 초록색으로 해놓았고 바로 불러올수 있는 수단이 전부 static 덕분이였어.

        int a_ABC = 100;                // <-- 지역 변수 사용 문제 없다.
        s_UserPoint = 1234;             // <-- 정적 맴버 변수 사용 문제 없다.
        Debug.Log(s_UserPoint);
    }
}
public class Test_052001 : MonoBehaviour
{
    private void Start()
    {
        Heros.s_UserPoint = 0;

        Heros ABC = new Heros();
        ABC.m_Name = "사냥꾼";
        ABC.m_Hp = 50;
        //ABC.s_UserPoint = 1;      //<-- 인스턴스. 으로 접근하는게 아니라서 에러난다.

        // 3 : 3 턴 방식 RPG 일 떄 캐릭터 3명을 선택해서 게임에 들어간 상황
        Heros AAA = new Heros();
        AAA.m_Name = "슈퍼맨";
        AAA.m_Hp = 123;
        Debug.Log(AAA.m_Name + " : " + AAA.m_Hp);
        AAA.AddUserPoint(100);

        Heros BBB = new Heros();
        BBB.m_Name = "스파이더맨";
        BBB.m_Hp = 98;
        Debug.Log(BBB.m_Name + " : " + BBB.m_Hp);
        BBB.AddUserPoint(130);

        Heros CCC = new Heros();
        CCC.m_Name = "아이언맨";
        CCC.m_Hp = 70;
        Debug.Log(CCC.m_Name + " : " + CCC.m_Hp);
        CCC.AddUserPoint(30);

        Debug.Log(Hero.s_UserPoint + " : " + AAA.GetUserPoint() + " : " + BBB.GetUserPoint() + " : " + CCC.GetUserPoint()); ;
    }
}
