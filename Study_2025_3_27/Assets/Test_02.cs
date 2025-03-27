using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// 변수
// 데이터를 저장하는 메모리 공간 (데이터를 담을 수 있는 상자)
// 변수의 선언 : 데이터형 변수명 = 초기값;
public class Test_02 : MonoBehaviour
{
    private int age;
    private float height;


    // Start is called before the first frame update
    void Start()
    {
        // char
        // c, c++ : char 1Byte 아스키 코드
        // c# : char 2Byte 유니 코드
        char ccdd = 'k';        // <-- C# 에서 ' ' 감싸주면 문자 하나를 의미한다.
        ccdd = '글';
        Debug.Log(ccdd);

        byte ggg = 255;         // 0 ~ 255까지 담을 수 있는 1Byte 짜리 변수 선언
        long xxx = 123L;        // 8바이트짜리 정수를 담는 데이터형 변수 선언

        Debug.Log(ggg);
        Debug.Log(xxx);

        // --초기값에 따라서 데이터형이 결정되는 데이터형
        // var 라는 데이터형은 초기값을 반드시 줘야 한다.
        //var vv1 = 123;          //int 형으로 확정
        //var vv2 = 3.14f;        //float 형으로 확정
        //var vv3 = "seoul";      //string 형으로 확정
        //var vv4 = true;         //bool 형으로 확정


        //Debug.Log("int size: " + sizeof(int)); // 4 bytes
        //Debug.Log("float size: " + sizeof(float)); // 4 bytes
    }

}
