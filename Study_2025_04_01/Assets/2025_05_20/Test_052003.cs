using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity C# 저장, 로딩 PlayerPrefabs

public class Test_052003 : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) == true)
        {   //저장
            PlayerPrefs.SetString("NickName", "팔라독");
            PlayerPrefs.SetInt("UserGold", 120);
            PlayerPrefs.SetInt("UserLevel", 11);
            PlayerPrefs.SetFloat("AttackRate", 0.57f);

            //PlayerPrefs.Save();   <-- 확실한 저장 (비정상 종료시 확인 저장 기능)
        }
        if(Input.GetKeyDown(KeyCode.L)== true)
        {   //로딩
            string a_Nick = PlayerPrefs.GetString("NickName", "");      // NickName 값이 없으면 초기값 "" 으로 설정
            int a_UserGold = PlayerPrefs.GetInt("UserGold", 0);
            int a_UserLevel = PlayerPrefs.GetInt("UserLevel", 1);
            float a_AttRate = PlayerPrefs.GetFloat("AttackRate", 0.0f);
        }
    }
}
