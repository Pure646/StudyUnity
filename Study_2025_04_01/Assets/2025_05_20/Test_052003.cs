using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity C# ����, �ε� PlayerPrefabs

public class Test_052003 : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) == true)
        {   //����        
            PlayerPrefs.SetString("NickName", "�ȶ�");       // PlayerPrefs �� ������ ���� �ʾƼ� �����ϰ� �����ϴ� �뵵
            PlayerPrefs.SetInt("UserGold", 120);              // ������ ���ᰡ �Ǵ��� ���� ����Ǿ��ִ� ���°� �Ǿ��ִ�.
            PlayerPrefs.SetInt("UserLevel", 11);
            PlayerPrefs.SetFloat("AttackRate", 0.57f);

            //PlayerPrefs.Save();   <-- Ȯ���� ���� (������ ����� Ȯ�� ���� ���)
        }
        if(Input.GetKeyDown(KeyCode.L)== true)
        {   //�ε�
            string a_Nick = PlayerPrefs.GetString("NickName", "");      // NickName ���� ������ �ʱⰪ "" ���� ����
            int a_UserGold = PlayerPrefs.GetInt("UserGold", 0);
            int a_UserLevel = PlayerPrefs.GetInt("UserLevel", 1);
            float a_AttRate = PlayerPrefs.GetFloat("AttackRate", 0.0f);

            Debug.Log("���� : " + a_Nick + ", ��� : " + a_UserGold +
                 ", ���� : " + a_UserLevel + ", ���ݷ� : " + a_AttRate);
        }

        if (Input.GetKeyDown(KeyCode.C) == true)
        {  //��ü����
            PlayerPrefs.DeleteAll();                    // �� ������Ʈ PlayerPrefabs�� ����� ��� ���� ����
            //PlayerPrefs.DeleteKey("UserLevel");       //Ư�� Ű���� �ʱ�ȭ �����ִ� �Լ�
        }
    }
}
