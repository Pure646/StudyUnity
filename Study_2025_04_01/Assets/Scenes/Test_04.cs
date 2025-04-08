using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제어문
// if : 조건문, 분기문
// if(조건식)
//{
//    실행될 코드
//}
//else if (조건식)
//{
//    실행될 코드
//}
//else
//{
//    실행될 코드
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
        // y = 11;      자기 소속 중괄호를 벗어나서 사용하려고 했기 때문에 에러난다.
        x = 4;
        if (x < 5)
        {
            Debug.Log("X는 5보다 작습니다.");
        }
        else if (x < 10)
        {
            Debug.Log("x는 5보다 크거나 같고");
            Debug.Log("x는 10보다 작습니다.");
        }
        else
        {
            Debug.Log("x는 10보다 크다.");
        }

        // if문의 3가지의 패턴
        Debug.Log("--- if문의 첫번째 패턴");
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
            Debug.Log(xyz + "는 확실 합니다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
