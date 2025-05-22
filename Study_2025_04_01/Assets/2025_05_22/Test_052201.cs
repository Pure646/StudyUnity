using System.Collections;
using System.Collections.Generic;       // 자료구조
using UnityEngine;

// C# 자료구조 (C# 자료구조 라이브러리 : Collection)
// C# Collections.Generic 중 List 

public class Test_052201 : MonoBehaviour
{
    // 정렬 조건 함수
    int Comp(int a, int b)
    {
        return a.CompareTo(b);      // 오름차순(ASC) : 낮은 값에서 높은 값으로 정렬(1, 2, 3, 4, 5, ...)
        //return b.CompareTo(a);      // 내림차순(DESC) : 높은 값에서 낮은 값으로 정렬(10, 9, 8, 7, ...)
    }
    private void Start()
    {
        // -- List 사용법
        List<int> a_List = new List<int>();
        Debug.Log("노드 추가 하기");
        a_List.Add(111);
        a_List.Add(222);
        a_List.Add(333);

        //for(int i = 0; i< a_List.Count; i++)
        //{
        //    Debug.Log(a_List[i]);
        //}
        Debug.Log("----");

        a_List.Add(444);
        a_List.Add(555);

        //for (int i = 0; i < a_List.Count; i++)
        //{
        //    Debug.Log(a_List[i]);
        //}

        foreach(int val in a_List)
        {
            Debug.Log(val);
        }

        Debug.Log("중간값 제거 하기");
        a_List.RemoveAt(1);

        for(int i = 0; i < a_List.Count; i++)
        {
            Debug.Log($"a_List[{i}] : " + a_List[i]);
        }

        Debug.Log("중간값 추가 하기");
        a_List.Insert(1, 1000);
        a_List.Insert(3, 3000);

        int a_Idx = 0;
        foreach(int val in a_List)
        {
            Debug.Log($"a_List[{a_Idx}] : {val}");
            a_Idx++;
        }

        Debug.Log("정렬하기");
        a_List.Sort(Comp);      // 함수이름 (정렬 조건 함수)

        for(int i = 0; i < a_List.Count; i++)
        {
            Debug.Log($"a_List[{i}] : {a_List[i]}");
        }

        Debug.Log("전체 노드 삭제하기");
        a_List.Clear();
        Debug.Log("노드의 개수 : " + a_List.Count);
    }
}
