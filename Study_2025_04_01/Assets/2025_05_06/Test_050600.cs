using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_050600 : MonoBehaviour
{
    private float aaa = 1;
    private float bbb = 1;
    private float ccc = 1;
    private float num = 0f;
    private void AAA()
    {
        aaa = aaa * 2;
        bbb = bbb * 2;
        ccc = aaa + bbb;
        num++;
        Debug.Log(ccc + " : " + num);

        if (num < 1000)
        {
            BBB();
        }
    }
    private void BBB()
    {
        aaa = aaa * 2;
        bbb = bbb * 2;
        ccc = aaa + bbb;
        num++;
        Debug.Log(ccc + " : " + num);

        if (num < 1000)
        {
            AAA();
        }
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AAA();
        }
    }
}
