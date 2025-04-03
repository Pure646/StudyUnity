using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Default_Result : MonoBehaviour
{
    public static Default_Result Instance { get; private set; }
    private Text cointext;
    public int Coin_Number => coin;
    private int coin;
    private void Awake()
    {
        cointext = GetComponent<Text>();
    }
    private void Start()
    {
        cointext.text = " x " + coin;
    }
}
