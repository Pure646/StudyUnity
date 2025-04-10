using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Study_Unity
{

    // 문자열형태 <--> 숫자형태
    public class Test_02 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            int ABC = 123;
            string BBB = "123";

            int KKK = 123 + ABC;        // 246
            string SSS = "123" + ABC;   // 123123       // ABC : 숫자형 -> 문자열로 바뀐다.

            //Debug.Log(KKK);
            //Debug.Log(SSS);

            ABC = 777;
            BBB = ABC.ToString();       // ToString : String 형태로 변환된다.
            BBB = "" + ABC;

            //문자열형태 --> 숫자형태
            string EEE = "123";
            //int FFF = EEE;    //형변환으로는 안되고 함수를 써야한다.
            //int FFF = int.Parse(EEE);       // 좀 위험한 함수 : 특수 문자가 끼어 있으면 에러난다.
            //Debug.Log(FFF);

            //int.TryParse()    //안전한 함수
            int FFF = 11;
            int.TryParse(EEE, out FFF);
            Debug.Log(FFF);
            FFF = FFF + 5000;
            Debug.Log(FFF);

            float PPP = 0.0f;
            float.TryParse("123 123", out PPP);
            Debug.Log(PPP);

            Debug.Log("<구구단 7단>");
            // 7 * 1 = 7;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}