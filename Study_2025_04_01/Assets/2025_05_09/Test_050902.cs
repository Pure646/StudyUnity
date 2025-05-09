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

    public void CavTA()
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
    // C#에서 접근 수식자를 생략하면 기본값은 private 속성이다.

    public void PrintInfo()
    {
        Debug.Log($"{m_Name} : 레벨({m_Level}) 성급({m_Star})" +
            $"가격 ({m_Price}) 공격상승률({m_AttackRate: N2}");
    }
}
// 접근수식자, 접근지정자
// public : 구조체, 클래스 내부와 외부에서 모두 접근해서 사용할 수 있는 속성
// private : 구조체, 클래스 내부에서만 사용 가능하고 외부에서는 접근할 수 없는 속성
// Protected : 외부에서 접근할 수 없고 , 자신과 상속관계의 자식 클래스까지는 접근을 허용하는 속성

public class Test_050902 : MonoBehaviour        // 유니티에 다양한 기능을 가지고 있는 MonoBehaviour 을 상속 받은 클래스 Test_050902
{
    private void Start()
    {
        //Student AA = new Student();
        Student[] AAA = new Student[3];            // 구조체 변수 선언
        for(int i = 0; i < AAA.Length; i++)
        {
            AAA[i].m_Name = $"너구리 {i + 1}";
            AAA[i].m_Kor = 100 - (i * i);
            AAA[i].m_Eng = 57 + (i * i);
            AAA[i].m_Math = 92 - (i * i);
            //AAA.m_Avg = 0.0f;       //private 속성은 구조체 변수를 통해서 외부에서 직접 접근할 수 없다.
            AAA[i].CavTA();
            AAA[i].PrintInfo();
        }
        Item MyItem = new Item();       // 클래스 변수 선언, 객체 선언(변수 선언), 인스턴스 선언(함수 선언)
        MyItem.m_Name = "천사의 날개";
        MyItem.m_Level = 3;
        MyItem.m_Star = 2;
        MyItem.m_Price = 1200;
        MyItem.PrintInfo();
    }


}
