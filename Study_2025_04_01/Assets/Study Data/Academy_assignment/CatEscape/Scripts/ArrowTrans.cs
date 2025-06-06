using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTrans : MonoBehaviour
{
    private DropArrow ArrowThrow;
    private GameObject player;
    private CatCharacter cat;
    private Image hp_gauge;
    private Text hp_text;
    private void Start()
    {
        player = GameObject.Find("player");
        ArrowThrow = FindObjectOfType<DropArrow>();
        cat = FindObjectOfType<CatCharacter>();
        hp_gauge = GameObject.Find("hp_gauge").GetComponent<Image>();
        hp_text = GameObject.Find("hp_Text").GetComponent<Text>();

        hp_text.text = $"{CatCharacter.CatHp} : {cat.MaxHp}";
    }
    private void Update()
    {
        transform.Translate(0, ArrowThrow.DropSpeed, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 fishT = transform.position;
        Vector2 CatT = player.transform.position;
        Vector2 dir = fishT - CatT;
        float mag = dir.magnitude;
        if(mag < 1f && CatCharacter.CatHp > 0)
        {
            CatCharacter.CatHp -= 1;
            if (hp_gauge.fillAmount > 0f)
            {
                hp_gauge.fillAmount -= (1f / cat.MaxHp);
                hp_text.text = $"{CatCharacter.CatHp} : {cat.MaxHp}";
            }
            Destroy(gameObject);
        }
    }
}
