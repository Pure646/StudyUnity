using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �迭
// ���� �������� �������� ����
public class Text_042501 : MonoBehaviour
{
    // ����Ƽ���� �迭�� �ɹ� ������ �����ؼ� ����ϴ� 2���� ���
    int[] m_Brr = new int[5];           // <-- �ɹ� �迭 ���� ���� (1�� ���)

    public int[] Crr;                   // <-- �ɹ� �迭 ���� ���� (2�� ���)

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
        Debug.Log("arr ���� : " + arr.Length);

        //--- �ɹ� �迭 ���� ��� �� (1�� ���)
        m_Brr[0] = 11;
        m_Brr[1] = 12;
        m_Brr[2] = 13;
        m_Brr[3] = 14;
        m_Brr[4] = 15;

        for(int i = 0; i < m_Brr.Length; i++)
        {
            Debug.Log($"m_Brr[{i}] : {m_Brr[i]}");
        }

        //--- �ɹ� �迭 ���� ��� ��
        for (int i = 0; i < Crr.Length; i++)
        {
            Debug.Log($"Crr[{i}]: {Crr[i]}");
        }

        //--- ����� ����
        int[] a_AAA = new int[10];

        //--- �Ͻ��� ����
        int[] a_CCC = { 10, 20, 30, 40, 50, 60 };
        for (int i = 0; i < a_CCC.Length; i++) 
        {
            Debug.Log(a_CCC[i]);
        }
    }
}
