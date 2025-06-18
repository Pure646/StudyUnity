using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointArrow : MonoBehaviour
{
    private static float FinalPoint;
    private GameObject cat;
    private Image[] Heart = new Image[3];
    private Text Point_Tx;
    public static int HealthPoint = 6;
    public static bool Hit;

    public GameObject GameOver;
    private Text Total_Tx;
    private float TotalPoint = 0;

    [SerializeField] private GameObject Arrow;
    private int TimeCount = 2;

    private void Start()
    {
        cat = GameObject.Find("cat");
        for (int i = 0; i < Heart.Length; i++)
        {
            Heart[i] = GameObject.Find($"Heart_Number{i + 1}").GetComponent<Image>();
            Heart[i].fillAmount = 1;
        }

        Point_Tx = GameObject.Find("Point").GetComponent<Text>();
    }

    private void Update()
    {
        if(cat.transform.position.y >= TotalPoint)
        {
            TotalPoint = cat.transform.position.y;
        }
        Point_Tx.text = $"Point : {(cat.transform.position.y).ToString("F2")}  ";
        if(Hit == true)
        {
            if(HealthPoint == 6)
            {
                Heart[2].fillAmount = 1f;
            }
            else if(HealthPoint == 5)
            {
                Heart[2].fillAmount = 0.5f;
            }
            else if(HealthPoint == 4)
            {
                Heart[2].fillAmount = 0f;
                Heart[1].fillAmount = 1f;
            }
            else if(HealthPoint == 3)
            {
                Heart[1].fillAmount = 0.5f;
            }
            else if(HealthPoint == 2)
            {
                Heart[1].fillAmount = 0f;
                Heart[0].fillAmount = 1f;
            }
            else if(HealthPoint == 1)
            {
                Heart[0].fillAmount = 0.5f;
            }
            else if(HealthPoint == 0)
            {
                Heart[0].fillAmount = 0f;
                GameOver.SetActive(true);
                Total_Tx = GameObject.FindObjectOfType<Text>();
                Total_Tx.text = $"Total : {TotalPoint.ToString("F2")}";
            }
            else if(HealthPoint >= 7)
            {
                HealthPoint = 6;
            }
            Hit = false;
        }

        if(TimeCount <= Time.time)
        {
            TimeCount = TimeCount + 2;
            int RandomNumber = Random.Range(1, 6);
            GameObject clone = Instantiate(Arrow, new Vector2(-3.5f + (1.75f * (RandomNumber - 1)), cat.transform.position.y + 30f), Quaternion.identity);
        }

    }
}
