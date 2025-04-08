using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEditorInternal.ReorderableList;

public class Coin_Scripts : MonoBehaviour
{
    private Text UI_Text;
    private GameObject textObject;
    private int coin;
    private void Awake()
    {
        textObject = GameObject.Find("CoinText");
        if(textObject != null)
        {
            UI_Text = textObject.GetComponentInChildren<Text>();
        }
    }
    private void Start()
    {
        Debug.Log(Default_Result.Instance.coin);
    }
    private void OnDestroy()
    {
        if(UI_Text != null)
        {
            Default_Result.Instance.coin++;
            coin = Default_Result.Instance.coin;
            UI_Text.text = " x " + coin.ToString("000");
        }
    }
}
