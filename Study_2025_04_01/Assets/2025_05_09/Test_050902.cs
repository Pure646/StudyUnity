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

    public void CacTA()
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

    //public float AttackRate     // �Ӽ�, ������Ƽ property
    //{
    //    get => m_AttackRate;
    //    set => m_AttackRate = value;
    //}

    public float AttackRate     // �Ӽ�, ������Ƽ property        // ������ ���ؼ�  // �߿��� ��� ���� ��?
    {
        get     // ����
        {
            return m_AttackRate;
        }

        set     // �б�
        {
            if (value < 0.0f || 10000.0f < value)
                return;
            m_AttackRate = value;
        }
    }

    // C#���� ���� �����ڸ� �����ϸ� �⺻���� private �Ӽ��̴�.

    public float GetAttackRate()
    {
        // ��ȣȭ
        return m_AttackRate;
    }

    public void SetAttackRate(float value)
    {
        // ��ȣȭ
        m_AttackRate = value;
    }

    public void PrintInfo()
    {
        Debug.Log($"{m_Name} : ����({m_Level}) ����({m_Star})" +
            $"���� ({m_Price}) ���ݻ�·�({m_AttackRate: N2}");
    }
    public void CopyItem(Item a_Item)       // <--- �Ϲ� ���� �Լ�
    {   // �Ϲ��Լ��� �ƴ϶� �������Լ��� �����Լ��� ����� �� " ���������" ��� �Ѵ�.
        m_Name = a_Item.m_Name;
        m_Level = a_Item.m_Level;
        m_Star = a_Item.m_Star;
        m_Price = a_Item.m_Price;
        m_AttackRate = a_Item.m_AttackRate;
    }
}
// ���ټ�����, ����������
// public : ����ü, Ŭ���� ���ο� �ܺο��� ��� �����ؼ� ����� �� �ִ� �Ӽ�
// private : ����ü, Ŭ���� ���ο����� ��� �����ϰ� �ܺο����� ������ �� ���� �Ӽ�
// Protected : �ܺο��� ������ �� ���� , �ڽŰ� ��Ӱ����� �ڽ� Ŭ���������� ������ ����ϴ� �Ӽ�

public class Test_050902 : MonoBehaviour        // ����Ƽ�� �پ��� ����� ������ �ִ� MonoBehaviour �� ��� ���� Ŭ���� Test_050902
{
    [HideInInspector] public int m_Gold;                  // �ν����� â�� �Ⱥ��̰� �ϰ�, public �� ����� �� ����.

    private int gold;
    public int Gold { get => gold; set => gold = value; } // �ν����� â�� �Ⱥ��̰� �ϰ�, public �� ����� �� ����.

    private void Start()
    {
        int XXX = 11;       // Value Type
        int YYY = XXX;      // ���� ����(Deep Copy) : ������ ��ü�� ��°�� �����ϰ�
                            // ����� �� ��ü�� ������ �������� �޸𸮸� �����ϴ� ��

        YYY = 999;
        Debug.Log(XXX + " : " + YYY);   // 11 : 999

        int[] ABC = { 11, 0 };     // Reference Type
        int[] XYZ = ABC;        // ���� ����(Shllow Copy) : �� ��ü�� �����ϴ� ���� �ƴ϶�
                                // �޸��� �ּҰ��� �����Ͽ� ���� �޸𸮸� �����ϴ� ��
        XYZ[0] = 999;
        Debug.Log(ABC[0] + " : " + XYZ[0]);     // 999 : 999
        XYZ[1] = 100000;
        Debug.Log(ABC[1]);

        Student AAA = new Student();
        AAA.m_Name = "������";
        AAA.m_Kor = 7777;
        AAA.m_Eng = 7777;
        AAA.m_Math = 7777;
        AAA.CacTA();

        Student a_TestVal = AAA;
        a_TestVal.m_Name = "���";
        a_TestVal.m_Kor = 99;
        a_TestVal.m_Eng = 99;
        a_TestVal.m_Math = 99;
        a_TestVal.CacTA();
        Debug.Log("--- ����ü Value Type Test ---");
        AAA.PrintInfo();
        a_TestVal.PrintInfo();
        Debug.Log("--- ����ü Value Type Test ---");

        Item myItem = new Item();       // Ŭ���� ���� ����, ��ü ����(���� ����), �ν��Ͻ� ����(�Լ� ����)
        myItem.m_Name = "õ���� ����";
        myItem.m_Level = 3;
        myItem.m_Star = 2;
        myItem.m_Price = 1200;
        myItem.PrintInfo();

        //--- Ŭ���� Reference Type Test
        Item a_TestRef = myItem;
        a_TestRef.m_Name = "�巡���� �����";
        a_TestRef.m_Level = 999;
        a_TestRef.m_Star = 999;
        a_TestRef.m_Price = 999;
        Debug.Log("--- Ŭ���� Reference Type Test ---");
        myItem.PrintInfo();             // <--- �巡���� �����
        a_TestRef.PrintInfo();          // <--- �巡���� �����
        Debug.Log("--- Ŭ���� Reference Type Test ---");

        ////Student AA = new Student();
        //Student[] AAA = new Student[3];            // ����ü ���� ����
        //for(int i = 0; i < AAA.Length; i++)
        //{
        //    AAA[i].m_Name = $"�ʱ��� {i + 1}";
        //    AAA[i].m_Kor = 100 - (i * i);
        //    AAA[i].m_Eng = 57 + (i * i);
        //    AAA[i].m_Math = 92 - (i * i);
        //    //AAA.m_Avg = 0.0f;       //private �Ӽ��� ����ü ������ ���ؼ� �ܺο��� ���� ������ �� ����.
        //    AAA[i].CavTA();
        //    AAA[i].PrintInfo();
        //}

        Item BBB = new Item();
        BBB.m_Name = "õ���� ����";
        BBB.m_Level = 10;
        BBB.m_Star = 10;
        BBB.m_Price = 10;
        //BBB.m_AttackRate = 1.2f;
        BBB.SetAttackRate(1.2f);
        Debug.Log("���ݻ�·� : " + BBB.GetAttackRate());

        BBB.AttackRate = 1.2f;
        Debug.Log("���ݻ�·� : " + BBB.AttackRate);

        //--- Ŭ���� Reference Type Test 
        Item a_TestReff = BBB;
        a_TestReff.m_Name = "�巡���� ����";
        a_TestReff.m_Level = 999;
        a_TestReff.m_Star = 999;
        a_TestReff.m_Price = 999;
        BBB.PrintInfo();
        a_TestReff.PrintInfo();

        Debug.Log("--------");
        Item XYX = new Item();
        XYX.CopyItem(BBB);
        XYX.PrintInfo();
        XYX.m_Name = "�ȶ��� ��";
        XYX.PrintInfo();
        BBB.PrintInfo();
    }
}
