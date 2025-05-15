using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref, out : Value Type�� �������� Reference Type ó�� ���� �����ִ� Ű����
// ref : ������ (�Ű������� �Ѱ� ���� ������ �޼���ȿ��� ������� �ʾƵ� �ȴ�.)
// out : ������ (�Ű������� �Ѱ� ���� ������ �޼���ȿ��� �ݵ�� ����ؾ� �Ѵ�.)
public class Test_051502 : MonoBehaviour
{
    void ValueMethod(int a_ii)
    {
        a_ii = 1000;
    }
    void RefMethod(ref int a_ii)            // ref �� ���� ������ ���ص� ������.
    {
        a_ii = 1000;
        Debug.Log("Test : " + a_ii);
    }
    void OutMethod(out int a_ii)            // out �� ���� ������ �ݵ�� �ؾ��Ѵ�.
    {
        a_ii = 1000;
        Debug.Log("Test : " + a_ii);
    }

    int Testing(int a, int b, ref int c, ref float d, ref bool e)
    {
        c = a + 3;
        return a + b;
    }

    void Start()
    {
        int aaa = 0;
        int bbb = aaa;
        bbb = 999;
        Debug.Log(aaa + " : " + bbb);   // 0 : 999

        int xxx = 0;
        ref int vvv = ref xxx;
        vvv = 999;
        Debug.Log(xxx + " : " + vvv);   // 999 : 999

        int ccc = 0;
        ValueMethod(ccc);
        Debug.Log("ccc : " + ccc);  // 0

        int eee = 0;
        RefMethod(ref eee);
        Debug.Log("eee : " + eee);

        int fff = 0;
        OutMethod(out fff); ;
        Debug.Log("fff : " + fff);

        string a_mm = "123.456";
        float a_rst = -1.0f;
        bool isOk = float.TryParse(a_mm, out a_rst);        // ���ڿ��� �Ǽ������� ��ȯ.
        if(isOk == true)
        {
            Debug.Log("a_rst : " + a_rst);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
