using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구조체 (struct)
// 같은 목적을 갖는 여러 데이터형 변수들과 메서드들의 집합
// 구조체 객체는 Value Type 이다.
// 구조체의 주 용도 : 상대적으로 간략한 데이터 값을 저장하는데 사용된다.
// 구조체는 상속 될 수 없다.

// 클래스 (class)
// 같은 목적을 갖는 여러 데이터형 변수들과 메서드들의 집합
// 클래스 객체는 Reference Type 이다.
// 클래스의 주 용도 : 소프트웨어를 부품화 (객체지향 프로그래밍) 하기 위한 도구로 사용된다.
// 클래스는 상속 될 수 있다.

// Value Type의 변수 : int , float , double, ... , struct (구조체)
// Reference Type의 변수 : 배열 , class 객체

// 구조체 (struct)
public struct Student       //<-- 구조체 정의 (설계도)
{
    public string m_Name;   //<-- 맴버변수
    public int m_Kor;
    public int m_Eng;
    public int m_Math;
    public int m_Total;
    float m_Avg;        // c#에서는 구조체에서 public 속성을 생략하면 기본 속성은 private 속성이 된다.

    public void CacTA()
    {       //총점과 평균을 계산하는 메서드 정의
        m_Total = m_Kor + m_Eng + m_Math;
        m_Avg = m_Total / 3.0f;
    }

    public void PrintInfo()     //<-- 맴버 메서드의 정의
    {
        Debug.Log($"이름({m_Name}) : 국어({m_Kor}) 영어({m_Eng}) 수학({m_Math})");
        Debug.Log($"총점({m_Total}) 평균 ({m_Avg.ToString("N2")})");
    }
}

public class Item 
{
    public string m_Name;
    public int m_Level;
    public int m_Star;
    public int m_Price;
    private float m_AttackRate = 1.0f;

    //public float AttackRate     // 속성, 프로퍼티 property
    //{
    //    get => m_AttackRate;
    //    set => m_AttackRate = value;
    //}

    public float AttackRate     // 속성, 프로퍼티 property        // 나중을 위해서  // 중요한 요소 만들 떄?
    {
        get     // 쓰기
        {
            return m_AttackRate;
        }

        set     // 읽기
        {
            if (value < 0.0f || 10000.0f < value)
                return;
            m_AttackRate = value;
        }
    }

    // C#에서 접근 수식자를 생략하면 기본값은 private 속성이다.

    public float GetAttackRate()
    {
        // 복호화
        return m_AttackRate;
    }

    public void SetAttackRate(float value)
    {
        // 암호화
        m_AttackRate = value;
    }

    public void PrintInfo()
    {
        Debug.Log($"{m_Name} : 레벨({m_Level}) 성급({m_Star})" +
            $"가격 ({m_Price}) 공격상승률({m_AttackRate: N2}");
    }
    public void CopyItem(Item a_Item)       // <--- 일반 복사 함수
    {   // 일반함수가 아니라 생성자함수로 복사함수를 만드는 걸 " 복사생성자" 라고 한다.
        m_Name = a_Item.m_Name;
        m_Level = a_Item.m_Level;
        m_Star = a_Item.m_Star;
        m_Price = a_Item.m_Price;
        m_AttackRate = a_Item.m_AttackRate;
    }
}
// 접근수식자, 접근지정자
// public : 구조체, 클래스 내부와 외부에서 모두 접근해서 사용할 수 있는 속성
// private : 구조체, 클래스 내부에서만 사용 가능하고 외부에서는 접근할 수 없는 속성
// Protected : 외부에서 접근할 수 없고 , 자신과 상속관계의 자식 클래스까지는 접근을 허용하는 속성

public class Test_050902 : MonoBehaviour        // 유니티에 다양한 기능을 가지고 있는 MonoBehaviour 을 상속 받은 클래스 Test_050902
{
    [HideInInspector] public int m_Gold;                  // 인스펙터 창에 안보이게 하고, public 을 사용할 수 있음.

    private int gold;
    public int Gold { get => gold; set => gold = value; } // 인스펙터 창에 안보이게 하고, public 을 사용할 수 있음.

    private void Start()
    {
        int XXX = 11;       // Value Type
        int YYY = XXX;      // 깊은 복사(Deep Copy) : 데이터 자체를 통째로 복사하고
                            // 복사된 두 객체는 완전히 독립적인 메모리를 차지하는 것

        YYY = 999;
        Debug.Log(XXX + " : " + YYY);   // 11 : 999

        int[] ABC = { 11, 0 };     // Reference Type
        int[] XYZ = ABC;        // 얕은 복사(Shllow Copy) : 값 자체를 복사하는 것이 아니라
                                // 메모리의 주소값을 복사하여 같은 메모리를 참조하는 것
        XYZ[0] = 999;
        Debug.Log(ABC[0] + " : " + XYZ[0]);     // 999 : 999
        XYZ[1] = 100000;
        Debug.Log(ABC[1]);

        Student AAA = new Student();
        AAA.m_Name = "람쥐썬더";
        AAA.m_Kor = 7777;
        AAA.m_Eng = 7777;
        AAA.m_Math = 7777;
        AAA.CacTA();

        Student a_TestVal = AAA;
        a_TestVal.m_Name = "상어";
        a_TestVal.m_Kor = 99;
        a_TestVal.m_Eng = 99;
        a_TestVal.m_Math = 99;
        a_TestVal.CacTA();
        Debug.Log("--- 구조체 Value Type Test ---");
        AAA.PrintInfo();
        a_TestVal.PrintInfo();
        Debug.Log("--- 구조체 Value Type Test ---");

        Item myItem = new Item();       // 클래스 변수 선언, 객체 선언(변수 선언), 인스턴스 선언(함수 선언)
        myItem.m_Name = "천사의 날개";
        myItem.m_Level = 3;
        myItem.m_Star = 2;
        myItem.m_Price = 1200;
        myItem.PrintInfo();

        //--- 클래스 Reference Type Test
        Item a_TestRef = myItem;
        a_TestRef.m_Name = "드래곤의 목걸이";
        a_TestRef.m_Level = 999;
        a_TestRef.m_Star = 999;
        a_TestRef.m_Price = 999;
        Debug.Log("--- 클래스 Reference Type Test ---");
        myItem.PrintInfo();             // <--- 드래곤의 목걸이
        a_TestRef.PrintInfo();          // <--- 드래곤의 목걸이
        Debug.Log("--- 클래스 Reference Type Test ---");

        ////Student AA = new Student();
        //Student[] AAA = new Student[3];            // 구조체 변수 선언
        //for(int i = 0; i < AAA.Length; i++)
        //{
        //    AAA[i].m_Name = $"너구리 {i + 1}";
        //    AAA[i].m_Kor = 100 - (i * i);
        //    AAA[i].m_Eng = 57 + (i * i);
        //    AAA[i].m_Math = 92 - (i * i);
        //    //AAA.m_Avg = 0.0f;       //private 속성은 구조체 변수를 통해서 외부에서 직접 접근할 수 없다.
        //    AAA[i].CavTA();
        //    AAA[i].PrintInfo();
        //}

        Item BBB = new Item();
        BBB.m_Name = "천사의 반지";
        BBB.m_Level = 10;
        BBB.m_Star = 10;
        BBB.m_Price = 10;
        //BBB.m_AttackRate = 1.2f;
        BBB.SetAttackRate(1.2f);
        Debug.Log("공격상승률 : " + BBB.GetAttackRate());

        BBB.AttackRate = 1.2f;
        Debug.Log("공격상승률 : " + BBB.AttackRate);

        //--- 클래스 Reference Type Test 
        Item a_TestReff = BBB;
        a_TestReff.m_Name = "드래곤의 반지";
        a_TestReff.m_Level = 999;
        a_TestReff.m_Star = 999;
        a_TestReff.m_Price = 999;
        BBB.PrintInfo();
        a_TestReff.PrintInfo();

        Debug.Log("--------");
        Item XYX = new Item();
        XYX.CopyItem(BBB);
        XYX.PrintInfo();
        XYX.m_Name = "팔라독의 검";
        XYX.PrintInfo();
        BBB.PrintInfo();
    }
}
