using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메서드의 디폴트 매개변수

public class Test_050901 : MonoBehaviour
{
    public void Test(int AAA , int BBB = -1)        // int 값에다가 미리 넣어주면 에러가 나오지 않음.
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

    private void Person(string name, int age = 0, string address = "")      // 뒤에서부터 채워주어야 에러가 안남.
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
    //private void Person(string name, int age)                       //<--- 함수의 오버로드
    //{
    //    Debug.Log(name + " : " + age);
    //}
    //private void Person(string name, int age, string address)       //<--- 함수의 오버로드
    //{
    //    Debug.Log(name + " : " + age + " : " + address);
    //}

    private void Start()
    {
        Person("민호", 23, "서울특별시");
        Person("홀길동", 12);
        Person("승호");

        Test(1234);
        Test(4321);
        Test(111, 222);         // int BBB = 222

        Hello();
    }
}
