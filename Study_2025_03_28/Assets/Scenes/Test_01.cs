using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ȯ
// 1, �ڵ� ����ȯ
// ���� �ٸ� �������� ������ �����ϰų�, ������ �� �� �ڵ����� ����ȯ �Ǵ� ��Ģ
// ��, ���� �ٸ� �������� �� �� ū �����θ� ��� ��ȯ�Ǵ� Ư¡�� �ִ�.
// ���������� ũ�� ����
// double > float > ulong > long > uint > int > ushort > short > char

// (���������� �������� ū������ ������ ������,
// �ݴ�� �����Ͱ��� ū���� ������������ ������ �� �� ����.)

// 2, ���� ����ȯ


public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1, �ڵ� ����ȯ
        int ii = 345;
        float ff = ii;  // �ڵ� ����ȯ 345.0f
        //int aa = ff;  // C# ������ ū ���������� ���� ���������� �ڵ����� ������ �� ����.

        //Debug.Log("ii : " + ii + ", ff : " + ff);

        //char ABC = '��';
        //string BBB = "�ݰ�����";

        long aaa = 123;     // �ڵ� ����ȯ 123L : 8����Ʈ¥�� ������ ��� �������� ���� ����
        float bbb = aaa;
        //long ccc = bbb;       // err

        //Debug.Log(aaa + " : " + sizeof(long));

        //Debug.Log("char : " + sizeof(char));
        //Debug.Log("short : " + sizeof(short));
        //Debug.Log("ushort : " + sizeof(ushort));
        //Debug.Log("int : " + sizeof(int));
        //Debug.Log("uint : " + sizeof(uint));
        //Debug.Log("long : " + sizeof(long));
        //Debug.Log("ulong : " + sizeof(ulong));
        //Debug.Log("float : " + sizeof(float));
        //Debug.Log("double : " + sizeof(double));

        // 2, ���� ����ȯ
        float a_ff = 12.34f;
        int a_ii = (int)a_ff;   // <-- ���� ����ȯ(���� ����ȯ)
        Debug.Log("a_ii : " + a_ii);

        float xxx = 123.456789123f;
        int MyInt = (int)xxx;
        float MyFloat = xxx - (int)xxx;     // 123.456f - 123.0f
        //Debug.Log(MyInt + " : " + MyFloat); // 123 : 0.4560013
        Debug.Log(xxx);
        Debug.Log((int)xxx);
        Debug.Log(MyFloat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
