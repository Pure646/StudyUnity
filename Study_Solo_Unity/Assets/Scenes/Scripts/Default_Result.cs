using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Default_Result : MonoBehaviour
{
    public static Default_Result Instance
    {
        get;
        private set;
    }
    private Text cointext;
    public int coin_Number
    {
        get => coin;
        set => coin = value;
    }
    private int coin;
    private int currentCoin;
    private void Awake()
    {
        cointext = GetComponent<Text>();
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        coin = 0;
        currentCoin = -1;
    }
    private void Update()
    {
        if (currentCoin != coin)
        {
            CoinText();
        }
    }
    private void CoinText()
    {
        cointext.text = " x " + coin.ToString("000");
        currentCoin = coin;
    }
}
