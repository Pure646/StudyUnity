using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 형변환
// 1, 자동 형변환
// 서로 다른 데이터형 변수에 대입하거나, 연산을 할 때 자동으로 형변환 되는 규칙
// 단, 서로 다른 데이터형 일 때 큰 쪽으로만 상승 변환되는 특징이 있다.
// 데이터형의 크기 순서
// double > float > ulong > long > uint > int > ushort > short > char

// (데이터형이 작은것은 큰쪽으로 대입이 되지만,
// 반대로 데이터값이 큰쪽이 작으로쪽으로 대입을 할 수 없다.)

// 2, 수동 형변환


public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1, 자동 형변환
        int ii = 345;
        float ff = ii;  // 자동 형변환 345.0f
        //int aa = ff;  // C# 에서는 큰 데이터형을 작은 데이터형에 자동으로 대입할 수 없다.

        //Debug.Log("ii : " + ii + ", ff : " + ff);

        //char ABC = '글';
        //string BBB = "반가워요";

        long aaa = 123;     // 자동 형변환 123L : 8바이트짜리 정수를 담는 데이터형 변수 선언
        float bbb = aaa;
        //long ccc = bbb;       // err

        //Debug.Log(aaa + " : " + sizeof(long));

        //Debug.Log("char : " + sizeof(char));
        //Debug.Log("short : " + sizeof(short));
        //Debug.Log("ushort : " + sizeof(ushort));
        //Debug.Log("int : " + sizeof(int));
        //Debug.Log("uint : " + sizeof(uint));
        //Debug.Log("long : " + sizeof(long));
        //Debug.Log("ulong : " + sizeof(ulong));
        //Debug.Log("float : " + sizeof(float));
        //Debug.Log("double : " + sizeof(double));

        // 2, 수동 형변환
        float a_ff = 12.34f;
        int a_ii = (int)a_ff;   // <-- 수동 형변환(강제 형변환)
        Debug.Log("a_ii : " + a_ii);

        float xxx = 123.456789123f;
        int MyInt = (int)xxx;
        float MyFloat = xxx - (int)xxx;     // 123.456f - 123.0f
        //Debug.Log(MyInt + " : " + MyFloat); // 123 : 0.4560013
        Debug.Log(xxx);
        Debug.Log((int)xxx);
        Debug.Log(MyFloat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
