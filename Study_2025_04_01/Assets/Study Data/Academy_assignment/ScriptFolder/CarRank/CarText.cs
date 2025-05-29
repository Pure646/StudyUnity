using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarText : MonoBehaviour
{
    private List<GameObject> Player = new List<GameObject>();
    private GameObject Distance;

    private GameObject car;
    private GameObject flag;
    private void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");

        for(int i = 0; i < 3; i++)
        {
            Player.Add(this.car);
            this.Player[i] = GameObject.Find($"Player_{i + 1}");
        }

        this.Distance = GameObject.Find("Distance");
    }

    private void Update()
    {
        float Result = car.transform.position.x - flag.transform.position.x;
        this.Distance.GetComponent<Text>().text = "목표 지점까지 : " + Result.ToString("F2");
    }
}
