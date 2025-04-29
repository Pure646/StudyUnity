using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_042901 : MonoBehaviour
{
    // 배열
    // 같은 데이터형 변수들의 집합

    // Value Type의 변수 : int , float , double , ... , struct (구조체)
    // Reference Type의 변수 : 배열 , class 객체

    private void Start()
    {
        int AAA = 1000;
        int BBB = AAA;      // 일반함수
        BBB = 99;
        Debug.Log("AAA : " + AAA + ", BBB : " + BBB);

        int[] CCC = { 1000, 0};                                     // { , } 공간
        Debug.Log(CCC[0]);
        int[] DDD = CCC;        // 배열변수는 원본 저장공간을 잠조한다는 뜻에서 Reference Type
                                // 배열 자체 공간만을 복사한다.
        Debug.Log("CCC[0] : " + CCC[0] + ", DDD[0] : " + DDD[0]);
        DDD[0] = 99;
        Debug.Log("CCC[0] : " + CCC[0] + ", DDD[0] : " + DDD[0]);
        CCC[0] = 100000;
        Debug.Log("CCC[0] : " + CCC[0] + ", DDD[0] : " + DDD[0]);
        CCC[1] = 100;
        DDD[1] = 200;
        Debug.Log("CCC[0] : " + CCC[1] + ", DDD[0] : " + DDD[1]);
        int[] EEE = DDD;
        Debug.Log("CCC[0] : " + CCC[0] + ", DDD[0] : " + DDD[0] + ", EEE[0] : "+ EEE[0]);

        int[] ZZZ = new int[3];
        ZZZ[0] = 10;
        ZZZ[1] = 11;
        ZZZ[2] = 12;

        ZZZ = new int[5];
        ZZZ[3] = 999;
        ZZZ[4] = 9999;

        for(int i = 0; i < ZZZ.Length; i++)
        {
            Debug.Log(ZZZ[i]);
        }
    }
}
