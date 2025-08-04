using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageTxt : MonoBehaviour
{
    private Text DmgTxt;
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    public void InitDamage(float damage, Color color)
    {
        if(DmgTxt == null)
        {
            DmgTxt = GetComponentInChildren<Text>();
        }
        if(damage < 0.0f)
        {
            int a_damage = (int)Mathf.Abs(damage);
            DmgTxt.text = "- " + a_damage;
        }
        else
        {
            DmgTxt.text = "+ " + (int)damage;
        }
        color.a = 1.0f;
        DmgTxt.color = color;
    }
}
