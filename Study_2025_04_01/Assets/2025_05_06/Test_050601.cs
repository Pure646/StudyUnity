using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_050601 : MonoBehaviour
{
    // �������� �Ű������� ���� �޼����� ����
    // 1, �������� �Ű������� ��� �����ϴ� ����
    // 2, return���� ����, �Ű������� �ִ� ����
    // 3, return���� ����, �Ű������� ���� ����
    // 4, return���� �ְ�, �Ű������� ���� ����

    // 1, return���� �Ű������� ��� �����ϴ� ����
    public int Sum(int a, int b)
    {
        int c = a + b;
        return c;
    }
    public int MyMethod(int a, int b)
    {
        int c = a + b;      //<--- �޼����� ���� (���赵)
        return c;
    }

    // 2, return ���� ����, �Ű������� �ִ� ����
    public void Hamsu(int Kor, int Eng, int Math)
    {   // void  : ���ϰ��� ���ٴ� �ǹ� (���ϰ��� �������� �ʾƵ� �ȴ�.

        int a_Hap = Kor + Eng + Math;
        Debug.Log("���� : " +  a_Hap);

        if (a_Hap < 20)
            return;

        Debug.Log("��� : " + (a_Hap / 3.0f).ToString("F2"));
    }

    // 3, return ���� ����, �Ű������� ���� ����
    public void PrintGuGuDan()
    {
        int a_Dan = 7;
        for (int i = 1; i < 10; i++)
        {
            Debug.Log(a_Dan + " * " + i + " = " + (a_Dan * i));
        }
    }

    // 4, return ���� �ְ�, �Ű������� ���� ����
    float m_Velocity = 10.0f;       // �ɹ�����
    public bool IsMove()
    {
        if(m_Velocity <= 0.0f)
        {
            return false;
        }
        return true;
    }
    private void Start()
    { // ����Ƽ�� �̺�Ʈ �Լ� : �츮�� ȣ���� ���� �ʾƵ� ����Ƽ�� �ڵ� ȣ���� �ִ� �Լ�
        // ����Ƽ �ý����� Ư�� ��Ȳ�� �°� ȣ���� �ִ� �Լ� : �ݹ��Լ�

        // �Ű�����, parameter, ����(�μ�)

        int AAA = MyMethod(111, 222);       //<--- �޼����� ȣ�� (�޼����� ���)

        int BBB = MyMethod(12, 34);

        int CCC = MyMethod(77, 88);

        //Debug.Log(AAA + " : " + BBB + " : " + CCC);

        Sum(11, 25); //<-- �������� �ִ� �Լ����� ���ϰ��� �޾Ƽ� ������� �ʾƵ� �ȴ�.
        int ABC = Sum(11, 25) + 99;
        //Debug.Log(ABC);

        //Hamsu(50, 10, 30);
        //Hamsu(1, 2, 3);

        PrintGuGuDan();

        if(IsMove() == true)
        {
            Debug.Log("�����̰� �־�");
        }
        else
        {
            Debug.Log("���� �־�");
        }
    }
}
