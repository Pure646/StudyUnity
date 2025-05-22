using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drop
{ 
    public class Item
    {
        public string m_Name = "";          //������ �̸�
        public int m_Level = 0;             //������ ����
        public float m_AttRate = 1.0f;      //���� ��·�
        public int m_Price = 100;           //������ ����

        public Item()       //������ �Լ�
        {   //�������� ���� Ŭ���� �̸��� �Ȱ��� �޼��� : ������ �Լ�
            //��ü ������ �ѹ� �ڵ����� ȣ��ǰ� �ַ� �ɹ� �������� �ʱ�ȭ�� �ִ� ������ �Ѵ�.

        }

        public Item(string name, int level, float attRate, int price)   //������ �����ε� �Լ�
        {
            m_Name = name;
            m_Level = level;
            m_AttRate = attRate;
            m_Price = price;
        }
        public void PrintInfo()
        {
            Debug.Log($"�̸�({m_Name}) : ����({m_Level}) ���ݻ�·�({m_AttRate}) ����({m_Price})");
        }
    }
}
public class Test_052202 : MonoBehaviour
{
    List<Drop.Item> m_ItList = new List<Drop.Item>();

    private void Start()
    {
        //--��� �߰�
        //��ü ����� ���ÿ� �ʱ�ȭ �ϴ� ���
        Drop.Item a_Node = new Drop.Item("õ���� ����", 3, 2.0f, 2500);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("�ȶ��� ��", 1, 1.2f, 1200);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("�ü��� Ȱ", 4, 1.7f, 1700);
        m_ItList.Add(a_Node);

        a_Node = new Drop.Item("�ź����� ����", 5, 1.5f, 3000);
        m_ItList.Add(a_Node);

        //for(int i = 0; i < m_ItList.Count; i++)
        //{
        //    m_ItList[i].PrintInfo();
        //}

        //Debug.Log("----");
        //m_ItList.RemoveAt(0);
        //Debug.Log("--- ù��° ��� ���� ��� ---");

        //foreach(Drop.Item a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //// ������ ��� ���� ���
        //if(0 < m_ItList.Count)
        //    m_ItList.RemoveAt(m_ItList.Count - 1); // ������ �ε��� ����

        ////RemoveAt() �Լ��� ����Ʈ�� ������ ��� �ε����� �����Ϸ��� �õ��ϸ� ��������.

        ////����� ������ ã�Ƽ� �����ϴ� ���
        //Drop.Item a_FNode = new Drop.Item("�ʱ����� ��ȭ", 1, 1.1f, 100);
        //m_ItList.Remove(a_FNode);
        ////Remove �Լ��� ��ü�� ����Ʈ�� �������� ���� ���¿��� ���� �õ��� �ص� ������ ���� �ʴ´�.

        //// �߰� �߰��� ���ǿ� �����ϴ� ��츸 ���������� �����ϱ�.
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

        //--- �߰��� �߰�
        m_ItList.Insert(1, new Drop.Item("����� �̻�", 4, 1.2f, 1200));
        Debug.Log("--- 1�� �ε����� �߰��� �߰� ��� ---");
        foreach(Drop.Item a_It in m_ItList)
        {
            a_It.PrintInfo();
        }
        //--- �߰��� �߰�
    }
}
