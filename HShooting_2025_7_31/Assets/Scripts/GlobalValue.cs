using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue
{
    public static string g_NickName = "User";   //유저의 별명
    public static int g_BestScore = 0;          //최고 점수
    public static int g_UserGold = 0;           //보유 게임 머니

    public static void LoadGameData()
    {
        g_NickName  = PlayerPrefs.GetString("NickName", "사냥꾼");
        g_BestScore = PlayerPrefs.GetInt("BestScore", 0);
        g_UserGold  = PlayerPrefs.GetInt("UserGold", 0);
    }

}//public class GlobalValue
