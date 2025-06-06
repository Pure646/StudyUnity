using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Drop
{ 
    public class Item
    {
        public string m_Name = "";          //아이템 이름
        public int m_Level = 0;             //아이템 레벨
        public float m_AttRate = 1.0f;      //공격 상승률
        public int m_Price = 100;           //아이템 가격

        public Item()       //생성자 함수
        {   //리턴형이 없고 클래스 이름과 똑같은 메서드 : 생성자 함수
            //객체 생성시 한번 자동으로 호출되고 주로 맴버 변수들을 초기화해 주는 역할을 한다.

        }

        public Item(string name, int level, float attRate, int price)   //생성자 오버로드 함수
        {
            m_Name = name;
            m_Level = level;
            m_AttRate = attRate;
            m_Price = price;
        }
        public void PrintInfo()
        {
            Debug.Log($"이름({m_Name}) : 레벨({m_Level}) 공격상승률({m_AttRate}) 가격({m_Price})");
        }
    }
}
public class Test_052202 : MonoBehaviour
{
    List<Drop.Item> m_ItList = new List<Drop.Item>();

    int PriceASC(Drop.Item a, Drop.Item b)      //정렬 조건 함수
    {
        return a.m_Price.CompareTo(b.m_Price);      // 오름차순 정렬 (가격이 낮은 순에서 높은 순으로 정렬
    }

    int LevelDESC(Drop.Item a, Drop.Item b)     //정렬 조건 함수
    {
        return b.m_Level.CompareTo(a.m_Level);      // 내림차순 정렬 (레벨이 높은순에서 낮은순으로 정렬)
    }

    private void Start()
    {
        //--노드 추가
        //객체 선언과 동시에 초기화 하는 방법
        Drop.Item a_Node = new Drop.Item("천사의 반지", 3, 2.0f, 2500);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("팔라독의 검", 1, 1.2f, 1200);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("궁수의 활", 4, 1.7f, 1700);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("거북이의 갑옷", 5, 1.5f, 3000);
        m_ItList.Add(a_Node);

        //for(int i = 0; i < m_ItList.Count; i++)
        //{
        //    m_ItList[i].PrintInfo();
        //}

        //Debug.Log("----");
        //m_ItList.RemoveAt(0);
        //Debug.Log("--- 첫번째 노드 삭제 결과 ---");

        //foreach(Drop.Item a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //// 마지막 노드 삭제 방법
        //if(0 < m_ItList.Count)
        //    m_ItList.RemoveAt(m_ItList.Count - 1); // 마지막 인덱스 삭제

        ////RemoveAt() 함수는 리스트의 범위를 벗어난 인덱스를 제거하려고 시도하면 에러난다.

        ////노드의 내용을 찾아서 삭제하는 방법
        //Drop.Item a_FNode = new Drop.Item("너구리의 장화", 1, 1.1f, 100);
        //m_ItList.Remove(a_FNode);
        ////Remove 함수는 객체가 리스트에 존재하지 않은 상태에서 제거 시도를 해도 에러가 나지 않는다.

        //// 중간 중간에 조건에 만족하는 경우만 선택적으로 삭제하기.
        //for (int i = 0; i < m_ItList.Count;) 
        //{
        //    if (m_ItList[i].m_Price < 2000)
        //    {
        //        m_ItList.RemoveAt(i);
        //    }
        //    else
        //    {
        //        i++;
        //    }
        //}
        //foreach (Drop.Item a_It in m_ItList) 
        //{
        //    a_It.PrintInfo();
        //}

        ////--- 중간값 추가
        //m_ItList.Insert(1, new Drop.Item("상어의 이빨", 4, 1.2f, 1200));
        //Debug.Log("--- 1번 인덱스에 중간값 추가 결과 ---");
        //foreach(Drop.Item a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}
        ////--- 중간값 추가

        ////--- 정렬
        //--- 가격이 낮은 순에서 높은 순으로 정렬
        //Debug.Log("---");
        //m_ItList.Sort(PriceASC);

        //foreach(Drop.Item a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //List<Drop.Item> a_CopyList = m_ItList.ToList();     //using System.Linq;
        //a_CopyList.Sort(PriceASC);
        //Debug.Log("--- 가격이 낮은 순에서 높은 순으로 정렬");
        //foreach(Drop.Item a_It in a_CopyList)
        //{
        //    a_It.PrintInfo();
        //}

        ////--- 레벨이 높은순에서 낮은순으로 정렬
        //List<Drop.Item> a_CloneList = m_ItList.ToList();
        //a_CloneList.Sort(LevelDESC);
        //Debug.Log("--- 레벨이 높은순에서 낮은순으로 정렬 ---");
        //foreach (Drop.Item a_It in a_CloneList)
        //{
        //    a_It.PrintInfo();
        //}

        //Debug.Log("--- 추가된 순으로 보기 ---");
        //foreach(Drop.Item a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}
        ////--- 정렬

        ////--- 검색
        //Debug.Log("--- List 검색 ---");
        //Drop.Item a_FindNode = null;
        //for(int i = 0; i < m_ItList.Count; i++)
        //{
        //    if (m_ItList[i].m_Name == "상어의 이빨")
        //    {
        //        a_FindNode = m_ItList[i];
        //        break;
        //    }
        //}

        //if(a_FindNode !=null)
        //{
        //    a_FindNode.PrintInfo();
        //}

        Drop.Item a_FNode = m_ItList.Find((a_FN) => a_FN.m_Name == "팔라독의 검");
        if(a_FNode != null)
        {
            a_FNode.PrintInfo();
        }
        //--- 검색

        //--- 전체 노드 삭제
        m_ItList.Clear();
        Debug.Log("--- 전체 노드 삭제 결과 ---");
        Debug.Log(m_ItList.Count);
        //--- 전체 노드 삭제
    }
}
