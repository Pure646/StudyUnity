using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_05 : MonoBehaviour
{
    private void Start()
    {
        //switch ~case ��
        //switch (���ǽ�) // ���ǽ��� ����� ���� �� �ִ� �� : ������ , ���� , ���ڿ�
        //{
        //    case ���:
        //        ����� ���;
        //}
        int a_ii = 20;
        switch(a_ii % 2)
        {
            case 0:
                Debug.Log("¦���Դϴ�.");
                break;
            case 1:
                Debug.Log("Ȧ���Դϴ�.");
                break;
        }

        if ((a_ii % 2) == 0)
            Debug.Log("¦�� �Դϴ�.");
        else if ((a_ii % 2) == 1)
            Debug.Log("Ȧ�� �Դϴ�.");

        char a_Day = 'ȭ';       // C# char���� 2byte
        // -> ������ ȭ�����Դϴ�.
    }
}
