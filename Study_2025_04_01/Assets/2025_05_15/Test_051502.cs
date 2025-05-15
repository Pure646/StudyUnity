using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref, out : Value Type의 변수들을 Reference Type 처럼 동작 시켜주는 키워드
// ref : 유연함 (매개변수로 넘겨 받은 변수는 메서드안에서 사용하지 않아도 된다.)
// out : 엄격함 (매개변수로 넘겨 받은 변수는 메서드안에서 반드시 사용해야 한다.)
public class Test_051502 : MonoBehaviour
{
    void ValueMethod(int a_ii)
    {
        a_ii = 1000;
    }
    void RefMethod(ref int a_ii)            // ref 는 변수 선언을 안해도 괜찮다.
    {
        a_ii = 1000;
        Debug.Log("Test : " + a_ii);
    }
    void OutMethod(out int a_ii)            // out 는 변수 선언을 반드시 해야한다.
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
        bool isOk = float.TryParse(a_mm, out a_rst);        // 문자열을 실수형으로 변환.
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
