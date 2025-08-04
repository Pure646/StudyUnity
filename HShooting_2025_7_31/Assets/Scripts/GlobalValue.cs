using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue
{
    public static string g_NickName = "User";   //������ ����
    public static int g_BestScore = 0;          //�ְ� ����
    public static int g_UserGold = 0;           //���� ���� �Ӵ�

    public static void LoadGameData()
    {
        g_NickName  = PlayerPrefs.GetString("NickName", "��ɲ�");
        g_BestScore = PlayerPrefs.GetInt("BestScore", 0);
        g_UserGold  = PlayerPrefs.GetInt("UserGold", 0);
    }

}//public class GlobalValue
