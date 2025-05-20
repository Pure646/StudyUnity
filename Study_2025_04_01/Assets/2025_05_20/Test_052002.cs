using MyTeam;                           // namespace
using System.Collections;               // namespace
using System.Collections.Generic;       // namespace
using UnityEngine;                      // namespace

// C# 네임스페이스
// 같은 클래스 이름의 중복을 피하기 위해 클래스들을 그룹화 시켜 줄 때 사용되는 문법

public class Itemes
{
    public string m_Nick;
    public int m_Star;
    public float m_AttRate;
}
namespace MyTeam
{ 
    public class Itemes
    {
        public string m_Name;
        public int m_Level;
        public int m_Price;
    }
}

public class Test_052002 : MonoBehaviour
{
    private void Start()
    {
        Itemes AAA = new Itemes();
        AAA.m_Nick = "팔라독의 검";
        AAA.m_Star = 1;
        AAA.m_AttRate = 0.3f;
        Debug.Log(AAA.m_Nick + " : " + AAA.m_Star + " : " + AAA.m_AttRate);

        MyTeam.Itemes BBB = new MyTeam.Itemes();
        BBB.m_Name = "드래곤의 방패";
        BBB.m_Level = 4;
        BBB.m_Price = 1000;
        Debug.Log(BBB.m_Name + " : " + BBB.m_Level + " : " + BBB.m_Price);

        Monster CCC = new Monster();
        CCC.m_Name = "늑대";
        CCC.m_Hp = 100;
        CCC.m_Mp = 100;
        CCC.m_Attack = 20;
        CCC.PrintInfo();

        Monster DDD = new Monster();
        DDD.m_Name = "좀비";
        DDD.m_Hp = 150;
        DDD.m_Mp = 150;
        DDD.m_Attack = 30;
        DDD.PrintInfo();

        Monster EEE = new Monster();
        EEE.m_Name = "오크";
        EEE.m_Hp = 200;
        EEE.m_Mp = 200;
        EEE.m_Attack = 50;
        EEE.PrintInfo();
    }
}
