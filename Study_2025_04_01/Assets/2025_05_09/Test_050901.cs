using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޼����� ����Ʈ �Ű�����

public class Test_050901 : MonoBehaviour
{
    public void Test(int AAA , int BBB = -1)        // int �����ٰ� �̸� �־��ָ� ������ ������ ����.
    {
        if(BBB < 0)
        {
            int Result = AAA;
            Debug.Log("Result : " + Result);
        }
        else
        {
            int Result = AAA + BBB;
            Debug.Log("Result : " + Result);
        }
    }
    private void Hello(int AAA = 1)
    {
        Debug.Log("Hello World!");
    }

    private void Person(string name, int age = 0, string address = "")      // �ڿ������� ä���־�� ������ �ȳ�.
    {
        string a_Temp = name;
        if (0 < age)
        {
            a_Temp += " : " + age;
        }
        if (address != "")
        {
            a_Temp += " : " + address;
        }
        Debug.Log(a_Temp);
    }
    //private void Person(string name)
    //{
    //    Debug.Log(name);
    //}
    //private void Person(string name, int age)                       //<--- �Լ��� �����ε�
    //{
    //    Debug.Log(name + " : " + age);
    //}
    //private void Person(string name, int age, string address)       //<--- �Լ��� �����ε�
    //{
    //    Debug.Log(name + " : " + age + " : " + address);
    //}

    private void Start()
    {
        Person("��ȣ", 23, "����Ư����");
        Person("Ȧ�浿", 12);
        Person("��ȣ");

        Test(1234);
        Test(4321);
        Test(111, 222);         // int BBB = 222

        Hello();
    }
}
