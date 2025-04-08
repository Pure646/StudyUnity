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
    public int coin = 0;
    private void Awake()
    {
        cointext = GetComponent<Text>();
        if(Instance != null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        cointext.text = " x " + coin.ToString("000");
    }
}
