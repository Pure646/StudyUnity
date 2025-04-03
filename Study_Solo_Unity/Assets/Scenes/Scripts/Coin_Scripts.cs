using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Scripts : MonoBehaviour
{
    private Text UI_Text;
    private int coin;
    private void Awake()
    {
        GameObject textObject = GameObject.Find("CoinText");
        if(textObject != null)
        {
            UI_Text = textObject.GetComponentInChildren<Text>();
        }
    }
    private void OnDestroy()
    {
        coin = 1;
        if(Default_Result.Instance.Coin_Number < 1000)
        {
            //Default_Result.Instance.Coin_Number += coin;
            UI_Text.text = " x " + Default_Result.Instance.Coin_Number.ToString("000");
        }
    }
}
