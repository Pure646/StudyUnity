using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���
// if : ���ǹ�, �б⹮
// if(���ǽ�)
//{
//    ����� �ڵ�
//}
//else if (���ǽ�)
//{
//    ����� �ڵ�
//}
//else
//{
//    ����� �ڵ�
//}

public class Test_04 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 1;
        if (x == 1)
        {
            int y = 2;
            Debug.Log(x);
            Debug.Log(y);
        }
        // y = 11;      �ڱ� �Ҽ� �߰�ȣ�� ����� ����Ϸ��� �߱� ������ ��������.
        x = 4;
        if (x < 5)
        {
            Debug.Log("X�� 5���� �۽��ϴ�.");
        }
        else if (x < 10)
        {
            Debug.Log("x�� 5���� ũ�ų� ����");
            Debug.Log("x�� 10���� �۽��ϴ�.");
        }
        else
        {
            Debug.Log("x�� 10���� ũ��.");
        }

        // if���� 3������ ����
        Debug.Log("--- if���� ù��° ����");
        int xyz = 5;
        if (xyz == 4)
            Debug.Log(xyz);
        if (xyz == 5)
            Debug.Log(xyz);
        if (xyz == 6)
            Debug.Log(xyz);
        if (xyz == 7) 
            Debug.Log(xyz);

        if (xyz == 4)
            Debug.Log(xyz);
        else if (xyz == 5)
            Debug.Log(xyz);
        else if (xyz == 6)
            Debug.Log(xyz);
        else if (xyz == 5)
            Debug.Log(xyz + "�� Ȯ�� �մϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
