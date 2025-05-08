using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޼����� �����ε� (�Լ��� �����ε�)
// �ϳ��� �޼��� �̸����� �������� �޼��带 �����ϴ� ��
// �Ű������� ���ĸ� �ٸ��� ���� �޼��� �̸��� ����� �� �ִ�.
// �⺻�뵵 : �ϳ��� �Լ� �̸����� �پ��� �������� �Ű������� ���ϰ� ����ϱ� ���ؼ� ���Ǵ� ����

public class Test_050801 : MonoBehaviour
{
    int Plus(int a, int b)
    {
        return a + b;
    }
    //int Plus(int c, int d)        //<-- �Ű������� ������ ���� �޼��� �̸��� �̹� ���� �Ǿ� �־ ��������.
    //{
    //    return c + d;
    //}

    int Plus(float a, float b)      //<-- �޼����� �����ε� or �����ε� ��
    {
        return (int)(a * b);
    }

    int Plus(int c)                 //<-- �޼����� �����ε� or �����ε� ��
    {
        return c;
    }

    double Plus(double a, double b) //<-- �޼����� �����ε� or �����ε� ��
    {
        Debug.Log("double + double");
        return a + b;
    }

    //double Plus(int c, int d)     //<-- �Ű������� ������ ���� �޼��� �̸��� �̹� ���� �Ǿ� �־ ��������.
    //{
    //    return c + d;
    //}

    double Plus(int c, float d)     //<-- �޼����� �����ε� or �����ε� ��
    {
        return c + d;
    }

    private void Start()
    {
        Debug.Log(Plus(45, 70));
        Debug.Log(Plus(1.0f, 2.4f));
        Debug.Log(Plus(85));
        Debug.Log(Plus(3.5, 4.2));

        // ����Ƽ C#���� �����ϴ� �޼��� �����ε��� ��
        int iRand = Random.Range(1, 7);
        float fRand = Random.Range(1.5f, 3.14f);

        int AAA = 4;
        AAA = Mathf.Clamp(AAA, 0, 10);          // 0 <= AAA <= 10 �� ��   , ��� : AAA      
                                                // 0 > AAA �� ��          , ��� : 0
                                                // 10 < AAA �� ��         , ��� : 10
        Debug.Log(AAA);


        float BBB = 3.14f;
        BBB = Mathf.Clamp(BBB, -1f, 1f);
        Debug.Log(BBB);
    }
}
