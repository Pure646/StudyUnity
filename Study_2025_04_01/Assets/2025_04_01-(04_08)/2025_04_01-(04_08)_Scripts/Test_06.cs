using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_06 : MonoBehaviour
{
    public char a_Day;
    //private enum c_Day
    //{
    //    �� = 1,
    //    ȭ = 2,
    //    �� = 3,
    //    �� = 4,
    //    �� = 5,
    //    �� = 6,
    //    �� = 7,
    //}
    private void Start()
    {
        char b_Day = '��';

        if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == 'ȭ')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else if (a_Day == '��')
            Debug.Log($"������ {a_Day}���� �Դϴ�.");
        else
            Debug.Log("�ش��ϴ� ������ ��Ȯ�� �Է��� �ּ���.");

        switch(a_Day)
        {
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case 'ȭ':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            case '��':
                Debug.Log($"������ {a_Day}���� �Դϴ�.");
                break;
            default:
                Debug.Log("�ش��ϴ� ������ ��Ȯ�� �Է��� �ּ���.");
                break;
        }
    }
    private void Update()
    {
        // ����Ƽ �����Ϳ��� Ű���� �Է��� �� �� ���� �� Ȯ���� ������ ����
        // 1, GameView â�� �ѹ� Ŭ���� �ش�.
        // (����Ƽ ������ GameView â�� ��Ŀ�� ���¸� ���� ����� ����...)
        // 2, �� / �� Ű�� ������ �ִ� ���¿��� (�ѱ� �Է� ���´� �ȵȴ�.)
        // �ȵǴ� ��찡 ���� �� �ִ�.
        // (����Ű�� ���� �Է� ���¿����� ���� �Է� �޴´�.)
        
        if(Input.GetKey(KeyCode.Space)== true)
        {
            //int a_Rand = Random.Range(1, 101);      // 1���� 100���� ������ ���ڸ� �߻���Ű��
            //Debug.Log("������ : " + a_Rand);

            //int a_Dice = Random.Range(1, 7);
            //Debug.Log("�ֻ��� ������ : " + a_Dice);

            float a_FRd = Random.Range(0.0f, 10.0f);    // 0.0f ~ 10.0f ���� ������ ���ڸ� �߻����� ��.
            Debug.Log(a_FRd);
        }
    }
}
