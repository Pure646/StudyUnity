using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarText : MonoBehaviour
{
    private List<Text> Player_Text = new List<Text>();
    private List<float> Player_Number = new List<float>();
    private Text Distance;
    private GameObject car;
    private GameObject flag;
    private Button Reset_Btn;
    private CarSystem carSystem;

    private bool[] check = new bool[2];
    private int PlayerNumber = 0;
    private int maxPlayerNumber = 3;            // 최대 인원수
    private float zeroPoint;                    // 자동차와 깃발에 처음 사이에 거리
    private void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        for(int i = 0; i < maxPlayerNumber; i++)
        {
            Player_Text.Add(GameObject.Find($"Player_{i + 1}").GetComponent<Text>());
        }
        this.Distance = GameObject.Find("Distance").GetComponent<Text>();
        this.carSystem = this.car.GetComponent<CarSystem>();

        Reset_Btn = GameObject.Find("Reset").GetComponent<Button>();
        Reset_Btn.onClick.AddListener(ResetBtn);
        Reset_Btn.gameObject.SetActive(false);

        zeroPoint = flag.transform.position.x - car.transform.position.x;
        check[0] = false;                       // 실행 체크
        check[1] = true;                        // 마지막 대기 (단 1번 바뀜)
    }

    private void Update()
    {
        float Result = flag.transform.position.x - car.transform.position.x;
        if(carSystem.CarSpeed > 0f)
        {
            this.Distance.text = "목표 지점까지 : " + Result.ToString("F2");
            check[0] = true;
        }
        else if(carSystem.CarSpeed == 0f && check[0])
        {
            if(PlayerNumber < Player_Text.Count)   // 오버 방지
            {
                if (Result >= 0f)
                {
                    Player_Text[PlayerNumber].text = $"Player {PlayerNumber + 1} : " + Result.ToString("F2");
                    Player_Number.Add(Result);
                }
                else
                {
                    Player_Text[PlayerNumber].text = $"Player {PlayerNumber + 1} : " + zeroPoint;
                    Player_Number.Add(zeroPoint);
                }
                PlayerNumber++;
            }
            check[0] = false;
        }
        if(PlayerNumber == Player_Text.Count && check[1])
        {
            for (int i = 0; i < Player_Text.Count; i++) 
            {
                int Ranking = 3;
                for(int j = 0; j < Player_Text.Count; j++)
                {
                    if (Player_Number[i] < Player_Number[j])
                    {
                        Ranking--;
                    }
                    else if(i != j && Player_Number[i] == Player_Number[j])
                    {
                        Ranking--;
                    }
                }
                Player_Text[i].text += $" ({Ranking} 등)";
            }
            check[1] = false;
            Reset_Btn.gameObject.SetActive(true);
        }
    }
    private void ResetBtn()
    {
        SceneManager.LoadScene("Academy assignment CarRank");
    }
}
