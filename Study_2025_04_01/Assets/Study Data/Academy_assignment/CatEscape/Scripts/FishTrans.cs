using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishTrans : MonoBehaviour
{
    private GameObject player;
    private DropArrow ArrowThrow;
    private Text Gold;
    private void Start()
    {
        player = GameObject.Find("player");
        Gold = GameObject.Find("Gold").GetComponent<Text>();
        ArrowThrow = FindObjectOfType<DropArrow>();
    }
    private void Update()
    {
        transform.Translate(0, ArrowThrow.DropSpeed, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 fishT = transform.position;
        Vector2 CatT = player.transform.position;
        Vector2 dir = fishT - CatT;
        float mag = dir.magnitude;
        if(mag < 1f && CatCharacter.CatHp > 0)
        {
            int AddGold = 0;
            Renderer fisherer = gameObject.GetComponent<Renderer>();
            if(fisherer.material.color == Color.red)
            {
                AddGold = 1000;
            }
            else
            {
                AddGold = 100;
            }
            DropArrow.Gold += AddGold;
            Gold.text = $"Gold : {DropArrow.Gold}";
            Destroy(gameObject);
        }
    }
}
