using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ŭ���� �Ҽ� �ɹ� static(����) ���� , (�����޼���)
// <Ư¡>
// 1, ��ü �������� Ŭ�����̸�.������, Ŭ�����̸�.�޼����()
// 2, ���α׷��� ������ �� �޸𸮰� Ȯ���Ǽ� ���α׷��� ����� ������ �����ȴ�.         //Scene�� �ٲ� �ٲ����� �ʰ� �����ȴ�.
// 3, Ŭ���� �Ҽ������� �޸𸮸� Ŭ������ ������ �����ϰ� �����ȴ�.
// (���α׷� ����� �� ���� ���� �����ȴ�.)

// static�� ���� Ŭ�ι��ϰ� ���ȴ�.
public class Heros //<-��ü
{
    public string m_Name;   //<-- �Ϲ� �ɹ� ���� (�ν��Ͻ� �ɹ� ����)
    public int m_Hp;

    public static int s_UserPoint = 0;      //<-- ���� �ɹ� ���� (Ŭ���� �ɹ� ����)

    public void AddUserPoint(int a_Point)   //<-- �Ϲ� �ɹ� �޼��� (�ν��Ͻ� �ɹ� �޼���)
    {
        s_UserPoint += a_Point;
    }
    public int GetUserPoint()               //<-- �Ϲ� �ɹ� �޼���
    {
        return s_UserPoint;
    }

    public static void StaticPrint()        //<-- ���� �ɹ� �޼��� (Ŭ���� �ɹ� �޼���)
    {
        ////Heros man = new Heros();       // <-- �Ϲ� �ɹ� ������ ����ϱ� ���ؼ� �ʿ��ϴ�.
        //m_name = "�ȶ�";               // <-- �Ϲ� �ɹ� ���� ����� ��������.
        //man.m_Hp = 34;

        // ����Ƽ���� ������ �ִ� static method ��
        Debug.Log("Test");
        int AABB = Random.Range(1, 3);
        Vector3 a_Vec = Vector3.zero;        // Vector3 : ����ü
        //class �� �ʷϻ����� �س��Ұ� �ٷ� �ҷ��ü� �ִ� ������ ���� static �����̿���.

        int a_ABC = 100;                // <-- ���� ���� ��� ���� ����.
        s_UserPoint = 1234;             // <-- ���� �ɹ� ���� ��� ���� ����.
        Debug.Log(s_UserPoint);
    }
}
public class Test_052001 : MonoBehaviour
{
    private void Start()
    {
        Heros.s_UserPoint = 0;

        Heros ABC = new Heros();
        ABC.m_Name = "��ɲ�";
        ABC.m_Hp = 50;
        //ABC.s_UserPoint = 1;      //<-- �ν��Ͻ�. ���� �����ϴ°� �ƴ϶� ��������.

        // 3 : 3 �� ��� RPG �� �� ĳ���� 3���� �����ؼ� ���ӿ� �� ��Ȳ
        Heros AAA = new Heros();
        AAA.m_Name = "���۸�";
        AAA.m_Hp = 123;
        Debug.Log(AAA.m_Name + " : " + AAA.m_Hp);
        AAA.AddUserPoint(100);

        Heros BBB = new Heros();
        BBB.m_Name = "�����̴���";
        BBB.m_Hp = 98;
        Debug.Log(BBB.m_Name + " : " + BBB.m_Hp);
        BBB.AddUserPoint(130);

        Heros CCC = new Heros();
        CCC.m_Name = "���̾��";
        CCC.m_Hp = 70;
        Debug.Log(CCC.m_Name + " : " + CCC.m_Hp);
        CCC.AddUserPoint(30);

        Debug.Log(Hero.s_UserPoint + " : " + AAA.GetUserPoint() + " : " + BBB.GetUserPoint() + " : " + CCC.GetUserPoint()); ;
    }
}
