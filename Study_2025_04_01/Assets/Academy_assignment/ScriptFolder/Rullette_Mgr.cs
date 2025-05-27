using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rullette_Mgr : MonoBehaviour
{
    private List<Text> Number_Tx = new List<Text>();
    private List<Image> Image_Im = new List<Image>();
    public Image GaugeBar;
    public Text GaugeTx;

    public Text[] tx;
    public Image[] Img;
    public Button Rs_btn;

    private float Number_rising = 0;
    private float Rotation_Speed = 0;
    private bool OnClick;
    private void Start()
    {
        Application.targetFrameRate = 60;       // ÃÊ´ç 60
        QualitySettings.vSyncCount = 0;
        Rs_btn.onClick.AddListener(Reset_Btn);

        foreach (var ttx in tx)
        {
            ttx.text = "";
        }
        foreach(var Imgg in Img)
        {
            Imgg.color = Color.white;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset_Btn();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Number_rising = 0;
        }
        if(Input.GetMouseButton(0))
        {
            Gauge();
        }
        if(Input.GetMouseButtonUp(0))
        {
            Rotation_Speed = Number_rising;
            OnClick = true;
        }
        if(Rotation_Speed > 0)
        {
            transform.Rotate(0, 0, Rotation_Speed);

            Rotation_Speed -= 0.5f;
        }
        else if(Rotation_Speed <= 0 && OnClick)
        {
            OnClick = false;
            if(a_Num2 <= 5)
            {
                Rullette();
            }
        }
    }
    private void Gauge()
    {
        if(Number_rising < 100)
        {
            Number_rising = Number_rising + 1f;
        }
        GaugeBar.fillAmount = Number_rising / 100;
        GaugeTx.text = $"{(int)Number_rising} : 100";
    }

    private int a_Num2 = 0;
    private void Rullette()
    {
        float a_Angle = transform.eulerAngles.z; //0.0f ~359.999999f
        int a_Num = 0;

        Image_Im.Add(Img[a_Num2]);

        if (17.5f <= a_Angle && a_Angle < 54.5f)
        {
            a_Num = 8;
            Image_Im[a_Num2].color = new Color32(0, 138, 203 , 255);
        }
        else if (54.5f <= a_Angle && a_Angle < 90.0f)
        {
            a_Num = 9;
            Image_Im[a_Num2].color = new Color32(0, 90, 159 ,255);
        }
        else if (90.0f <= a_Angle && a_Angle < 125.5f)
        {
            a_Num = 0;
            Image_Im[a_Num2].color = new Color32(198, 0, 13 ,255);
        }
        else if (125.5f <= a_Angle && a_Angle < 162.0f)
        {
            a_Num = 1;
            Image_Im[a_Num2].color = new Color32(203, 85, 0 , 255);
        }
        else if (162.0f <= a_Angle && a_Angle < 198.0f)
        {
            a_Num = 2;
            Image_Im[a_Num2].color = new Color32(211, 130, 0, 255);
        }
        else if (198.0f <= a_Angle && a_Angle < 234.0f)
        {
            a_Num = 3;
            Image_Im[a_Num2].color = new Color32(222, 208, 0, 255);
        }
        else if (234.0f <= a_Angle && a_Angle < 270.0f)
        {
            a_Num = 4;
            Image_Im[a_Num2].color = new Color32(123, 170, 27, 255);
        }
        else if (270.0f <= a_Angle && a_Angle < 306.0f)
        {
            a_Num = 5;
            Image_Im[a_Num2].color = new Color32(27, 149, 49, 255);
        }
        else if (306.0f <= a_Angle && a_Angle < 342.0f)
        {
            a_Num = 6;
            Image_Im[a_Num2].color = new Color32(0, 133, 57, 255);
        }
        else
        {
            a_Num = 7;
            Image_Im[a_Num2].color = new Color32(0, 138, 129, 255);
        }
        Number_Tx.Add(tx[a_Num2]);
        Number_Tx[a_Num2].text = $"{a_Num}";

        a_Num2++;
    }
    private void Reset_Btn()
    {
        Number_Tx.Clear();
        a_Num2 = 0;
        foreach(var ttx in tx)
        {
            ttx.text = "";
        }
        foreach(var Imgg in Img)
        {
            Imgg.color = Color.white;
        }
    }
}
