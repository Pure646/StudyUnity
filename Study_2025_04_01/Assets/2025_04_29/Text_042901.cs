using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_042901 : MonoBehaviour
{
    // �迭
    // ���� �������� �������� ����

    // Value Type�� ���� : int , float , double , ... , struct (����ü)
    // Reference Type�� ���� : �迭 , class ��ü

    private void Start()
    {
        int AAA = 1000;
        int BBB = AAA;      // �Ϲ��Լ�
        BBB = 99;
        Debug.Log("AAA : " + AAA + ", BBB : " + BBB);

        int[] CCC = { 1000, 0};                                     // { , } ����
        Debug.Log(CCC[0]);
        int[] DDD = CCC;        // �迭������ ���� ��������� �����Ѵٴ� �濡�� Reference Type
                                // �迭 ��ü �������� �����Ѵ�.
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
