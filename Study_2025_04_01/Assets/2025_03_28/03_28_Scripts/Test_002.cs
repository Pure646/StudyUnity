using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Study_Unity
{

    // ���ڿ����� <--> ��������
    public class Test_02 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            int ABC = 123;
            string BBB = "123";

            int KKK = 123 + ABC;        // 246
            string SSS = "123" + ABC;   // 123123       // ABC : ������ -> ���ڿ��� �ٲ��.

            //Debug.Log(KKK);
            //Debug.Log(SSS);

            ABC = 777;
            BBB = ABC.ToString();       // ToString : String ���·� ��ȯ�ȴ�.
            BBB = "" + ABC;

            //���ڿ����� --> ��������
            string EEE = "123";
            //int FFF = EEE;    //����ȯ���δ� �ȵǰ� �Լ��� ����Ѵ�.
            //int FFF = int.Parse(EEE);       // �� ������ �Լ� : Ư�� ���ڰ� ���� ������ ��������.
            //Debug.Log(FFF);

            //int.TryParse()    //������ �Լ�
            int FFF = 11;
            int.TryParse(EEE, out FFF);
            Debug.Log(FFF);
            FFF = FFF + 5000;
            Debug.Log(FFF);

            float PPP = 0.0f;
            float.TryParse("123 123", out PPP);
            Debug.Log(PPP);

            Debug.Log("<������ 7��>");
            // 7 * 1 = 7;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}