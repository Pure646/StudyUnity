using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Btn : MonoBehaviour
{
    [SerializeField] private Button Start_btn;

    private void Start()
    {
        Start_btn.onClick.AddListener(StartButton);
    }
    private void StartButton()
    {
        NextScene.Instance.num = 2;
    }
}
