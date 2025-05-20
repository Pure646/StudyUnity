using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 생성자함수, 소멸자함수
// 생성자함수 : 
//      클래스이름과 똑같고, 리턴형이 없는 함수
//      클래스 객체를 생성할 때 자동으로 한번 호출되는 메서드
//      주로 맴버 변수들을 초기화 해 주는 용도로 사용된다.
// 소멸자함수 :
//      ~클래스이름과 똑같은 함수
//      객체의 메모리가 소멸 때 한번 자동으로 호출되는 함수

// 클래스에서는 생성자, 소멸자를 생략할 수 있다.
// 생성자, 소멸자를 생략해서 설계하고 객체를 만들게 되면
// 자동으로 디폴트 생성다, 디폴트 소멸자가 만들어지고 호출된다.

// 생성자를 모두 (생성자 오버로드 함수 포함) 생략하면 디폴트 생성자가 자동으로 만들어 진다.
// 생성자 오버로드 함수만 만들고 기본 생성자를 만들지 않으면 디폴트 생성자가 자동으로 만들어 지지 않는다.

// 디폴트 생성자 : 아무것도 없는 생성자.
public class MonsterHotel
{
    public string m_Name = "";          // 이름       //<-- 초기화 순서 1번
    public int m_Hp = 0;                // 체력
    public float m_Attack = 0;          // 공격력

    public MonsterHotel()    //<-- 생성자 메서드           //<-- 초기화 순서 2번
    {
        Debug.Log("생성자 메서드 호출");

        m_Name = "몬 1";
        m_Hp = 1;
        m_Attack = 1.0f;
    }

    ~MonsterHotel()          //<-- 소멸자 메서드           //시간이 지나면 자동으로 메모리가 정리가 되면서 삭제되고 소멸자 메서드가 나온다.
    {
        Debug.Log("소멸자 메서드 호출");
    }
    // 객체가 더 이상 참조되지 않아서 가비지 컬렉션의 대상이 될 때 호출됩니다.
    // 가비지 컬렉션 : 프로그래밍 언어에서 사용되지 않는 메모리를 자동으로 해제하여
    // **메모리 누수(memory leak)**를 방지하고 자원 관리를 효율적으로 할 수 있게 도와주는 시스템
    // 메모리 해제 : 프로그램이 더 이상 필요하지 않거나 사용되지 않는 데이터를 자동으로 찾아서 메모리에서 제거하고,
    // 그 공간을 다시 사용할 수 있도록 만드는 과정을 의미

    // ****가비지 컬렉션에 의해 메모리에서 객체가 삭제될 때 호출 때마다 소멸자 메서드가 실행이 된다****

    // 함수의 오버로드 : 매개변수의 형식이 다르면 같은 함수명을 사용할 수 있다.
    public MonsterHotel(string name)     // 생성자 오버로드 함수
    {
        m_Name = name;
    }
    public MonsterHotel(string name, int a_hp, float a_Att)
    {
        m_Name = name;
        m_Hp = a_hp;
        m_Attack = a_Att;
    }

    public void PrintInfo()
    {
        Debug.Log($"이름 : {m_Name} 체력({m_Hp}) 공격력({m_Attack})");
    }
}// public class Monster
public class Test_051501 : MonoBehaviour
{
    private void Start()
    {
        MonsterHotel AAA = new MonsterHotel();    // 변수 선언후 초기화
        AAA.PrintInfo();
        AAA.m_Name = "울프";                      //<-- 초기화 순서 3번
        AAA.m_Hp = 100;
        AAA.m_Attack = 30.0f;
        AAA.PrintInfo();

        int BBB;            // 변수 선언 후 초기화
        BBB = 111;
        Debug.Log(BBB);

        int CCC = 222;      // 변수 선언과 동시에 초기화
        Debug.Log(CCC);

        MonsterHotel a_MM = new MonsterHotel("사자", 78, 15.0f);
        a_MM.PrintInfo();

        MonsterHotel a_SS = new MonsterHotel("오크");
        a_SS.PrintInfo();
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    AAA.PrintInfo();
        //}
    }
}
