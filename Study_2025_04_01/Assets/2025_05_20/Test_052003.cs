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
            PlayerPrefs.SetString("NickName", "팔라독");       // PlayerPrefs 는 보안이 좋지 않아서 간단하게 저장하는 용도
            PlayerPrefs.SetInt("UserGold", 120);              // 게임을 종료가 되더라도 값이 저장되어있는 상태가 되어있다.
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

            Debug.Log("별명 : " + a_Nick + ", 골드 : " + a_UserGold +
                 ", 레벨 : " + a_UserLevel + ", 공격력 : " + a_AttRate);
        }

        if (Input.GetKeyDown(KeyCode.C) == true)
        {  //전체삭제
            PlayerPrefs.DeleteAll();                    // 이 프로젝트 PlayerPrefabs에 저장된 모든 정보 삭제
            //PlayerPrefs.DeleteKey("UserLevel");       //특정 키값을 초기화 시켜주는 함수
        }
    }
}
