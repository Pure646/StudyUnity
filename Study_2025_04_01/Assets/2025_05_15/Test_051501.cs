using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������Լ�, �Ҹ����Լ�
// �������Լ� : 
//      Ŭ�����̸��� �Ȱ���, �������� ���� �Լ�
//      Ŭ���� ��ü�� ������ �� �ڵ����� �ѹ� ȣ��Ǵ� �޼���
//      �ַ� �ɹ� �������� �ʱ�ȭ �� �ִ� �뵵�� ���ȴ�.
// �Ҹ����Լ� :
//      ~Ŭ�����̸��� �Ȱ��� �Լ�
//      ��ü�� �޸𸮰� �Ҹ� �� �ѹ� �ڵ����� ȣ��Ǵ� �Լ�

// Ŭ���������� ������, �Ҹ��ڸ� ������ �� �ִ�.
// ������, �Ҹ��ڸ� �����ؼ� �����ϰ� ��ü�� ����� �Ǹ�
// �ڵ����� ����Ʈ ������, ����Ʈ �Ҹ��ڰ� ��������� ȣ��ȴ�.

// �����ڸ� ��� (������ �����ε� �Լ� ����) �����ϸ� ����Ʈ �����ڰ� �ڵ����� ����� ����.
// ������ �����ε� �Լ��� ����� �⺻ �����ڸ� ������ ������ ����Ʈ �����ڰ� �ڵ����� ����� ���� �ʴ´�.

// ����Ʈ ������ : �ƹ��͵� ���� ������.
public class MonsterHotel
{
    public string m_Name = "";          // �̸�       //<-- �ʱ�ȭ ���� 1��
    public int m_Hp = 0;                // ü��
    public float m_Attack = 0;          // ���ݷ�

    public MonsterHotel()    //<-- ������ �޼���           //<-- �ʱ�ȭ ���� 2��
    {
        Debug.Log("������ �޼��� ȣ��");

        m_Name = "�� 1";
        m_Hp = 1;
        m_Attack = 1.0f;
    }

    ~MonsterHotel()          //<-- �Ҹ��� �޼���           //�ð��� ������ �ڵ����� �޸𸮰� ������ �Ǹ鼭 �����ǰ� �Ҹ��� �޼��尡 ���´�.
    {
        Debug.Log("�Ҹ��� �޼��� ȣ��");
    }
    // ��ü�� �� �̻� �������� �ʾƼ� ������ �÷����� ����� �� �� ȣ��˴ϴ�.
    // ������ �÷��� : ���α׷��� ���� ������ �ʴ� �޸𸮸� �ڵ����� �����Ͽ�
    // **�޸� ����(memory leak)**�� �����ϰ� �ڿ� ������ ȿ�������� �� �� �ְ� �����ִ� �ý���
    // �޸� ���� : ���α׷��� �� �̻� �ʿ����� �ʰų� ������ �ʴ� �����͸� �ڵ����� ã�Ƽ� �޸𸮿��� �����ϰ�,
    // �� ������ �ٽ� ����� �� �ֵ��� ����� ������ �ǹ�

    // ****������ �÷��ǿ� ���� �޸𸮿��� ��ü�� ������ �� ȣ�� ������ �Ҹ��� �޼��尡 ������ �ȴ�****

    // �Լ��� �����ε� : �Ű������� ������ �ٸ��� ���� �Լ����� ����� �� �ִ�.
    public MonsterHotel(string name)     // ������ �����ε� �Լ�
    {
        m_Name = name;
    }
    public MonsterHotel(string name, int a_hp, float a_Att)
    {
        m_Name = name;
        m_Hp = a_hp;
        m_Attack = a_Att;
    }

    public void PrintInfo()
    {
        Debug.Log($"�̸� : {m_Name} ü��({m_Hp}) ���ݷ�({m_Attack})");
    }
}// public class Monster
public class Test_051501 : MonoBehaviour
{
    private void Start()
    {
        MonsterHotel AAA = new MonsterHotel();    // ���� ������ �ʱ�ȭ
        AAA.PrintInfo();
        AAA.m_Name = "����";                      //<-- �ʱ�ȭ ���� 3��
        AAA.m_Hp = 100;
        AAA.m_Attack = 30.0f;
        AAA.PrintInfo();

        int BBB;            // ���� ���� �� �ʱ�ȭ
        BBB = 111;
        Debug.Log(BBB);

        int CCC = 222;      // ���� ����� ���ÿ� �ʱ�ȭ
        Debug.Log(CCC);

        MonsterHotel a_MM = new MonsterHotel("����", 78, 15.0f);
        a_MM.PrintInfo();

        MonsterHotel a_SS = new MonsterHotel("��ũ");
        a_SS.PrintInfo();
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    AAA.PrintInfo();
        //}
    }
}
