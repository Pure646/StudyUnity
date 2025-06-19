using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointArrow : MonoBehaviour
{
    [HideInInspector] public static float TotalPoint;
    [SerializeField] private Text DeadTotal;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private Image DashGage;

    private GameObject cat;
    private Image[] Heart = new Image[3];
    private Text Point_Tx;
    private Text Total_Tx;
    private float MyPoint = 0;
    private bool OnDash;
    public GameObject GameOver;
    public static int TimeCount = 2;
    public static int HealthPoint;
    public static bool Hit;

    private void Start()
    {
        cat = GameObject.Find("cat");
        for (int i = 0; i < Heart.Length; i++)
        {
            Heart[i] = GameObject.Find($"Heart_Number{i + 1}").GetComponent<Image>();
            Heart[i].fillAmount = 1;
        }

        Point_Tx = GameObject.Find("Point").GetComponent<Text>();
        Total_Tx = GameObject.Find("TotalPoint").GetComponent<Text>();
        Total_Tx.text = $" TotalPoint : {TotalPoint.ToString("F2")} ";

        HealthPoint = 6;
    }

    private void Update()
    {
        MyPoint = cat.transform.position.y;
        if(TotalPoint <= MyPoint)
        {
            TotalPoint = MyPoint;
            Total_Tx.text = $" TotalPoint : {TotalPoint.ToString("F2")} ";
        }
        Point_Tx.text = $"Point : {MyPoint.ToString("F2")}  ";
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
                DeadTotal.text = $"TotalPoint = {TotalPoint.ToString("F2")}";
            }
            else if(HealthPoint >= 7)
            {
                HealthPoint = 6;
            }
            Hit = false;
        }

        if(TimeCount <= Time.time && HealthPoint > 0)
        {
            TimeCount = TimeCount + 1;
            int RandomNumber = Random.Range(1, 6);
            GameObject clone = Instantiate(Arrow, new Vector2(-3.5f + (1.75f * (RandomNumber - 1)), cat.transform.position.y + 15f), Quaternion.identity);
        }
        if (CatController.UsedDash == true && OnDash)
        {
            DashGage.fillAmount = 0f;
            OnDash = false;
        }
        if(CatController.UsedDash == true && OnDash == false)
        {
            DashGage.fillAmount += Time.deltaTime;
            if(DashGage.fillAmount >= 1f)
            {
                CatController.UsedDash = false;
                OnDash = true;
            }
        }
    }
}
