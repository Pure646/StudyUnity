using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// ����
// �����͸� �����ϴ� �޸� ���� (�����͸� ���� �� �ִ� ����)
// ������ ���� : �������� ������ = �ʱⰪ;
public class Test_02 : MonoBehaviour
{
    private int age;
    private float height;


    // Start is called before the first frame update
    void Start()
    {
        // char
        // c, c++ : char 1Byte �ƽ�Ű �ڵ�
        // c# : char 2Byte ���� �ڵ�
        char ccdd = 'k';        // <-- C# ���� ' ' �����ָ� ���� �ϳ��� �ǹ��Ѵ�.
        ccdd = '��';
        Debug.Log(ccdd);

        byte ggg = 255;         // 0 ~ 255���� ���� �� �ִ� 1Byte ¥�� ���� ����
        long xxx = 123L;        // 8����Ʈ¥�� ������ ��� �������� ���� ����

        Debug.Log(ggg);
        Debug.Log(xxx);

        // --�ʱⰪ�� ���� ���������� �����Ǵ� ��������
        // var ��� ���������� �ʱⰪ�� �ݵ�� ��� �Ѵ�.
        //var vv1 = 123;          //int ������ Ȯ��
        //var vv2 = 3.14f;        //float ������ Ȯ��
        //var vv3 = "seoul";      //string ������ Ȯ��
        //var vv4 = true;         //bool ������ Ȯ��


        //Debug.Log("int size: " + sizeof(int)); // 4 bytes
        //Debug.Log("float size: " + sizeof(float)); // 4 bytes
    }

}
