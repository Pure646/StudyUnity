using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_042502 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1, 아래와 같은 배열이 있을 때 222 값은 몇번 인덱스에 있는지?
        // 인덱스를 찾는 코드를 작성하고 인덱스를 출력해 주세요.
        int[] App = { 34, 56, 12, 89, 120, 6, 8, 222, 67, 81, 110 };
        for(int i = 0; i < App.Length; i++)
        {
            if (App[i] == 222)
            {
                Debug.Log($"App[{i + 1}]");
                break;
            }
        }

        //2, 아래와 같은 배열이 있을 때 33 이라는 값은 몇번 인덱스에 있을까요?
        //또, 99 라는 값은 몇번 인덱스에 있을까요? 찾는 코드를
        //작성하고 인덱스를 출력해 주세요.
        int a_idx = 0;
        int[] a_VVV = new int[100];
        for (int i = 0; i < 100; i++)
        {
            if ((i % 3) == 0)
            {
                a_VVV[a_idx] = i;
                a_idx++;
            }
        }
        for (int i = 0; i < 100; i++)
        {
            if (a_VVV[i] == 33 || a_VVV[i] == 99)
            {
                Debug.Log($"{a_VVV[i]}이라는 index 값 : {i}");
            }
        }

        //3, 아래와 같은 배열이 있을 때 아래 보기와 같은 연산 후 결과를 출력해 주세요.
        int[] a_ZZZ = new int[100];
        for (int i = 0; i < 100; i++)
        {
            a_ZZZ[i] = i;
        }

        int[] a_rr = new int[100];
        for(int i = 0; i < 50; i++)
        {
            a_rr[i] = a_ZZZ[(i * 2)] + a_ZZZ[(i * 2) + 1];
            Debug.Log($"a_rr[{i}] : {a_rr[i]}");
            //Debug.Log($"a_ZZZ[{(i * 2)}] + a_ZZZ[{(i * 2) + 1}]");
        }
        //보기
        //a_rr[0] = a_ZZZ[0] + a_ZZZ[1];
        //a_rr[1] = a_ZZZ[2] + a_ZZZ[3];
        //a_rr[2] = a_ZZZ[4] + a_ZZZ[5];
        //a_rr[3] = a_ZZZ[6] + a_ZZZ[7];
        //     :
        //a_rr[??] = a_ZZZ[98] + a_ZZZ[99];

        // 결과 출력 for문으로 a_rr 배열 출력 예
        // a_rr[0] : 1
        // a_rr[1] : 5
        // a_rr[2] : 9
        //     :

        //4, 최대값, 최소값 구하기...
        int[] a_kk = { 23, 45, 12, 67, 34, 77, 103, 3, 6, 7, 9, 11, 65, 204, 33, 56 };
        //for문을 돌면서 최대값과 최소값을 구하고 최대값의 인덱스와 최소값의
        //인덱스를 같이 출력해 주세요.
        //출력 예시 : "최대값 : ?? (인덱스 ??), 최소값 : ?? (인덱스 ??)
        //int Bigger = 0;
        //int Smaller = 0;
        //int[] Number = new int[2];
        //int[] index = new int[2];
        //for (int i = 0; i < a_kk.Length; i++) 
        //{
        //    for (int k = 0; k < a_kk.Length; k++) 
        //    {
        //        if (a_kk[i] >= a_kk[k])
        //        {
        //            Bigger++;
        //        }
        //        if (a_kk[i] <= a_kk[k])
        //        {
        //            Smaller++;
        //        }
        //    }
        //    if(Bigger == a_kk.Length)
        //    {
        //        Number[0] = a_kk[i];
        //        index[0] = i;
        //    }
        //    if(Smaller == a_kk.Length)
        //    {
        //        Number[1] = a_kk[i];
        //        index[1] = i;
        //    }
        //    Bigger = 0;
        //    Smaller = 0;
        //}
        //Debug.Log($"최대값 : {Number[0]} (인덱스 : {index[0]}), 최소값 : {Number[1]} (인덱스 : {index[1]})");

        int a_Max = a_kk[0];    // int.MinValue;
        int a_Min = a_kk[0];    // int.MaxValue;

        int a_SvMaxIdx = 0;
        int a_SvMinIdx = 0;

        for(int i = 0; i < a_kk.Length; i++)
        {
            if(a_Max < a_kk[i])
            {
                a_Max = a_kk[i];
                a_SvMaxIdx = i;
            }
            if (a_kk[i] < a_Min)
            {
                a_Min = a_kk[i];
                a_SvMinIdx = i;
            }
        }
        Debug.Log($"최대값 : {a_Max} (인덱스 {a_SvMaxIdx}), 최소값 : {a_Min} (인덱스 {a_SvMinIdx})");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
