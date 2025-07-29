using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTxt_Ctrl : MonoBehaviour
{
    private Text DamageText;
    private void Start()
    {
        Destroy(gameObject, 1.05f);
    }
    public void InitDamage(float a_Damage, Color a_Color)
    {
        if (DamageText == null)
        {
            DamageText = GetComponentInChildren<Text>();
        }
        if (a_Damage < 0.0f)
        {
            int a_Dmg = (int)Mathf.Abs(a_Damage);
            DamageText.text = "- " + a_Dmg;
        }
        else
        {
            DamageText.text = "+ " + (int)a_Damage;
        }
        a_Color.a = 1.0f;
        DamageText.color = a_Color;
    }
}
