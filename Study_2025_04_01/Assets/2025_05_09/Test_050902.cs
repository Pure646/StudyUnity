using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ü (struct)
// ���� ������ ���� ���� �������� ������� �޼������ ����
// ����ü ��ü�� Value Type �̴�.
// ����ü�� �� �뵵 : ��������� ������ ������ ���� �����ϴµ� ���ȴ�.
// ����ü�� ��� �� �� ����.

// Ŭ���� (class)
// ���� ������ ���� ���� �������� ������� �޼������ ����
// Ŭ���� ��ü�� Reference Type �̴�.
// Ŭ������ �� �뵵 : ����Ʈ��� ��ǰȭ (��ü���� ���α׷���) �ϱ� ���� ������ ���ȴ�.
// Ŭ������ ��� �� �� �ִ�.

// Value Type�� ���� : int , float , double, ... , struct (����ü)
// Reference Type�� ���� : �迭 , class ��ü

// ����ü (struct)
public struct Student       //<-- ����ü ���� (���赵)
{
    public string m_Name;   //<-- �ɹ�����
    public int m_Kor;
    public int m_Eng;
    public int m_Math;
    public int m_Total;
    float m_Avg;        // c#������ ����ü���� public �Ӽ��� �����ϸ� �⺻ �Ӽ��� private �Ӽ��� �ȴ�.

    public void CavTA()
    {       //������ ����� ����ϴ� �޼��� ����
        m_Total = m_Kor + m_Eng + m_Math;
        m_Avg = m_Total / 3.0f;
    }

    public void PrintInfo()     //<-- �ɹ� �޼����� ����
    {
        Debug.Log($"�̸�({m_Name}) : ����({m_Kor}) ����({m_Eng}) ����({m_Math})");
        Debug.Log($"����({m_Total}) ��� ({m_Avg.ToString("N2")})");
    }
}

public class Item 
{
    public string m_Name;
    public int m_Level;
    public int m_Star;
    public int m_Price;
    private float m_AttackRate = 1.0f;
    // C#���� ���� �����ڸ� �����ϸ� �⺻���� private �Ӽ��̴�.

    public void PrintInfo()
    {
        Debug.Log($"{m_Name} : ����({m_Level}) ����({m_Star})" +
            $"���� ({m_Price}) ���ݻ�·�({m_AttackRate: N2}");
    }
}
// ���ټ�����, ����������
// public : ����ü, Ŭ���� ���ο� �ܺο��� ��� �����ؼ� ����� �� �ִ� �Ӽ�
// private : ����ü, Ŭ���� ���ο����� ��� �����ϰ� �ܺο����� ������ �� ���� �Ӽ�
// Protected : �ܺο��� ������ �� ���� , �ڽŰ� ��Ӱ����� �ڽ� Ŭ���������� ������ ����ϴ� �Ӽ�

public class Test_050902 : MonoBehaviour        // ����Ƽ�� �پ��� ����� ������ �ִ� MonoBehaviour �� ��� ���� Ŭ���� Test_050902
{
    private void Start()
    {
        //Student AA = new Student();
        Student[] AAA = new Student[3];            // ����ü ���� ����
        for(int i = 0; i < AAA.Length; i++)
        {
            AAA[i].m_Name = $"�ʱ��� {i + 1}";
            AAA[i].m_Kor = 100 - (i * i);
            AAA[i].m_Eng = 57 + (i * i);
            AAA[i].m_Math = 92 - (i * i);
            //AAA.m_Avg = 0.0f;       //private �Ӽ��� ����ü ������ ���ؼ� �ܺο��� ���� ������ �� ����.
            AAA[i].CavTA();
            AAA[i].PrintInfo();
        }
        Item MyItem = new Item();       // Ŭ���� ���� ����, ��ü ����(���� ����), �ν��Ͻ� ����(�Լ� ����)
        MyItem.m_Name = "õ���� ����";
        MyItem.m_Level = 3;
        MyItem.m_Star = 2;
        MyItem.m_Price = 1200;
        MyItem.PrintInfo();
    }


}
