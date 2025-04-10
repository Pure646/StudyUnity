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

        //string str = string.Format("{0} * {1} = {2}", a, b, (a * b));
        string str = $"{a} * {b} = {a * b}";
        Debug.Log(str);

        str = string.Format("{0} / {1} = {2}", a, b, (a / b));
        Debug.Log(str);

        str = $"{a} / {b} = {a / b}";
        Debug.Log(str);

        // % ������ ������
        Debug.Log($"{a} % {b} = {a % b}");
        // ���� ���ں��� �ϳ� ���� ������ �ݺ��Ǵ� Ư¡�� �ִ�.

        // 2, ���������� : ++ , --
        // C, C++ , C#
        int cc = 0;
        cc++;           // cc = cc + 1;     1���� ��Ű��� ��
        ++cc;           // �ܵ� ��ɾ�� ���� ���� �׳� 1���� ��Ű��� ��
        Debug.Log("�ܵ� ����� ��� : " + cc);

        cc = 0;
        Debug.Log(string.Format("���� ��ɾ�� ���� ��� �ڿ� ���� �� : {0}", cc++));

        cc = 0;
        Debug.Log(string.Format("���� ��ɾ�� ���� ��� �տ� ���� �� : {0}", ++cc));

        int ff = 10;
        ff--;           // ff = ff - 1;     //�ܵ����� ���� ���� 1���� ��Ű��� �ǹ�
        --ff;
        Debug.Log(ff);

        // 3, �Ҵ翬���� =, -=, +=, *=, /=, %=
        int a_xx = 10;
        a_xx += 5;
        //a_xx = a_xx + 1;      a_xx++;     a_xx += 1;
        a_xx -= 3;          //a_xx = a_xx -3;
        int a_yy = 10;
        a_yy *= 2;          //a_yy = a_yy * 2;
        a_yy /= 2;          //a_yy = a_yy / 2;
        a_yy %= 2;          //a_yy = a_yy % 2;

        // 4, �������� && , ||, !
        int ggg = 50;
        int hhh = 60;
        bool a_check = ggg > 40 && hhh > 50; // && : And ~�̰� , �׸���
        Debug.Log("ggg > 40 && hhh > 50 : " + a_check);
        // true  && true  = true
        // true  && false = false
        // false && true  = false
        // false && false = false

        a_check = ggg > 40 || hhh > 70;     // || : Or, ~�̰ų�, �Ǵ�
        Debug.Log("ggg > 40 || hhh > 70 : " + a_check);
        // true  || true  = true
        // true  || false = true
        // false || true  = true
        // false || false = false

        a_check = !(ggg > hhh);             // Not ����� ������Ű�� ������
        Debug.Log(a_check);
        // !true  = false
        // !false = true

        // 5, ���迬���� : <, >, >=, <=, ==, !=
        int AAA = 50;
        int BBB = 60;
        Debug.Log("AAA < BBB : " + (AAA < BBB));    // True
        Debug.Log("AAA > BBB : " + (AAA > BBB));    // False
        Debug.Log("AAA == BBB : " + (AAA == BBB));  // False
        Debug.Log("AAA != BBB : " + (AAA != BBB));  // True
        Debug.Log("AAA <= BBB : " + (AAA <= BBB));  // True
        Debug.Log("AAA >= BBB : " + (AAA >= BBB));  // False

        // 6, ��Ʈ������ : &, |, ^
        int nnn = 5;            // 0101
        int mmm = 10;           // 1010

        int Result = nnn & mmm; // 0000
        Debug.Log("nnn & mmm : " + Result);      // 0

        Result = nnn | mmm;     // 1111
        Debug.Log("nnn | mmm : " + Result);      // 15

        // ^ : XOR : ������ : �ΰ��� ������ 0, �� ���� �ٸ��� 1
        Result = nnn ^ mmm;     // 1111
        Debug.Log("nnn ^ mmm : " + Result);      // 15

        int kkk = 2357;
        int a_ScVal = kkk ^ 6789;       // ��ȣȭ
        Debug.Log("a_ScVal : " + a_ScVal);      // 5040
        int a_MyVal = a_ScVal ^ 6789;   // ��ȣȭ
        Debug.Log("a_MyVal : " + a_MyVal);      // 2357
    }
}
