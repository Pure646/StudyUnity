using System.Collections;
using System.Collections.Generic;       // �ڷᱸ��
using UnityEngine;

// C# �ڷᱸ�� (C# �ڷᱸ�� ���̺귯�� : Collection)
// C# Collections.Generic �� List 

public class Test_052201 : MonoBehaviour
{
    // ���� ���� �Լ�
    int Comp(int a, int b)
    {
        return a.CompareTo(b);      // ��������(ASC) : ���� ������ ���� ������ ����(1, 2, 3, 4, 5, ...)
        //return b.CompareTo(a);      // ��������(DESC) : ���� ������ ���� ������ ����(10, 9, 8, 7, ...)
    }
    private void Start()
    {
        // -- List ����
        List<int> a_List = new List<int>();
        Debug.Log("��� �߰� �ϱ�");
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

        Debug.Log("�߰��� ���� �ϱ�");
        a_List.RemoveAt(1);

        for(int i = 0; i < a_List.Count; i++)
        {
            Debug.Log($"a_List[{i}] : " + a_List[i]);
        }

        Debug.Log("�߰��� �߰� �ϱ�");
        a_List.Insert(1, 1000);
        a_List.Insert(3, 3000);

        int a_Idx = 0;
        foreach(int val in a_List)
        {
            Debug.Log($"a_List[{a_Idx}] : {val}");
            a_Idx++;
        }

        Debug.Log("�����ϱ�");
        a_List.Sort(Comp);      // �Լ��̸� (���� ���� �Լ�)

        for(int i = 0; i < a_List.Count; i++)
        {
            Debug.Log($"a_List[{i}] : {a_List[i]}");
        }

        Debug.Log("��ü ��� �����ϱ�");
        a_List.Clear();
        Debug.Log("����� ���� : " + a_List.Count);
    }
}
