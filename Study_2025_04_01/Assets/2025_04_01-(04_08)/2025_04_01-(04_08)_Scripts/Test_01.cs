using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_001 : MonoBehaviour
{
    // Start is called before the first frame update
    public int Number = 1;
    void Start()
    {
        // 1 ~ 10 합 문제풀이
        int Hap = 0;
        for(int i = 1; i<= Number; i++)
        {
            Debug.Log((Hap + i) + " = " + Hap + " + " + i);
            Hap = Hap + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
