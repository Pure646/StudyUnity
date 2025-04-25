using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배열
// 같은 데이터형 변수들의 집합
public class Text_042501 : MonoBehaviour
{
    // 유니티에서 배열을 맴버 변수로 선언해서 사용하는 2가지 방법
    int[] m_Brr = new int[5];           // <-- 맴버 배열 변수 선언 (1번 방법)

    public int[] Crr;                   // <-- 맴버 배열 변수 선언 (2번 방법)

    private void Start()
    {
        int[] arr = new int[5];
        arr[0] = 10;
        arr[1] = 20;
        arr[2] = 30;
        arr[3] = 40;
        arr[4] = 50;
        for(int i = 0; i < arr.Length; i++)
        {
            Debug.Log(arr[i]);
        }
        Debug.Log("arr 개수 : " + arr.Length);

        //--- 맴버 배열 변수 사용 예 (1번 방법)
        m_Brr[0] = 11;
        m_Brr[1] = 12;
        m_Brr[2] = 13;
        m_Brr[3] = 14;
        m_Brr[4] = 15;

        for(int i = 0; i < m_Brr.Length; i++)
        {
            Debug.Log($"m_Brr[{i}] : {m_Brr[i]}");
        }

        //--- 맴버 배열 변수 사용 예
        for (int i = 0; i < Crr.Length; i++)
        {
            Debug.Log($"Crr[{i}]: {Crr[i]}");
        }

        //--- 명시적 선언
        int[] a_AAA = new int[10];

        //--- 암시적 선언
        int[] a_CCC = { 10, 20, 30, 40, 50, 60 };
        for (int i = 0; i < a_CCC.Length; i++) 
        {
            Debug.Log(a_CCC[i]);
        }
    }
}
