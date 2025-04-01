using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연산자
// 1, 수식연산자 : + , - , * , / , %
// 2, 증감연산자 : ++ , --
// 3, 할당연산자 : = , -= , += , *= , /= , %=
// 4, 논리연산자 : && , || , !
// 5, 관계연산자 : < , > , == , <= , >= , !=
// 6, 비트연산자 : & , | , ^
public class Test_03 : MonoBehaviour
{
    private void Start()
    {
        // 1, 수식연산자 : + , - , * , / , %
        int a = 88, b = 22;
        int c = a + b;
        Debug.Log(a + " + " + b + " = " + c);

        c = a - b;
        Debug.Log(a + " - " + b + " = " + c);

        // 2, 증감연산자 : ++ , --
    }
}
