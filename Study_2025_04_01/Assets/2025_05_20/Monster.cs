using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTeam
{ 
    public class Monster
    {
        public string m_Name;   // 몬스터의 이름
        public int m_Hp;        // 체력
        public int m_Mp;        // 마나
        public int m_Attack;    // 공격력

        public void PrintInfo()
        {
            Debug.Log("이름 : " + m_Name + ", 체력(" + m_Hp + "), 마나(" + m_Mp + "), 공격력(" + m_Attack + ")");
        }
    }
}

