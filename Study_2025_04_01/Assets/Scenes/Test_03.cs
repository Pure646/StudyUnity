using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������
// 1, ���Ŀ����� : + , - , * , / , %
// 2, ���������� : ++ , --
// 3, �Ҵ翬���� : = , -= , += , *= , /= , %=
// 4, �������� : && , || , !
// 5, ���迬���� : < , > , == , <= , >= , !=
// 6, ��Ʈ������ : & , | , ^
public class Test_03 : MonoBehaviour
{
    private void Start()
    {
        // 1, ���Ŀ����� : + , - , * , / , %
        int a = 88, b = 22;
        int c = a + b;
        Debug.Log(a + " + " + b + " = " + c);

        c = a - b;
        Debug.Log(a + " - " + b + " = " + c);

        // 2, ���������� : ++ , --
    }
}
