using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListList : MonoBehaviour
{
    private List<float> ListInt = new List<float>();
    private Image Imagege;
    private List<Image> ListImg = new List<Image>();

    private float CurrentHealth = 7.3f;
    //void Start()
    //{
    //    for(int i = 0; i < 10; i++)
    //    {
    //        ListInt.Add(i);
    //        ListInt[i] = i;
    //    }
    //}
    private void Update()
    {
        for (int i = 0; i < ListInt.Count; i++)
        {
            float Hp = Mathf.Clamp01(CurrentHealth - i);
            ListImg.Add(Imagege);
            ListImg[i].fillAmount = Hp;
        }
    }
}
