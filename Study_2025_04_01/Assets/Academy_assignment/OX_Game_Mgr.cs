using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OX_Game : MonoBehaviour
{
    public Text[] Number_Text;
    public int[] Number;
    public Button[] OX_Button;

    private int User_OX = 10;
    private int Com_OX = 100;

    private int Random_Number;
    private void Start()
    {
        for (int i = 0; i < 9; i++) 
        {
            int index = i;
            Number[i] = 0;
            Number_Text[i].text = "";
            OX_Button[i].image.color = Color.yellow;
            OX_Button[i].onClick.AddListener(() => OX_vs_Com(index));
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OX_Reset();
        }
    }
    private void OX_vs_Com(int index)
    {
        User(index);
        Victory();
        StartCoroutine(Its_time());
    }
    private IEnumerator Its_time()
    {
        yield return new WaitForSeconds(0.1f);
        Computer();
        Defeat();
    }
    private void Victory()
    {
        if (Number[0] + Number[1] + Number[2] == 30 ||
            Number[3] + Number[4] + Number[5] == 30 ||
            Number[6] + Number[7] + Number[8] == 30 ||
            Number[0] + Number[3] + Number[6] == 30 ||
            Number[1] + Number[4] + Number[7] == 30 ||
            Number[2] + Number[5] + Number[8] == 30 ||
            Number[0] + Number[4] + Number[8] == 30 ||
            Number[2] + Number[4] + Number[6] == 30)
        {
            Debug.Log("승리");
            OX_Reset();
        }
    }
    private void Defeat()
    {
        if (Number[0] + Number[1] + Number[2] == 300 ||
            Number[3] + Number[4] + Number[5] == 300 ||
            Number[6] + Number[7] + Number[8] == 300 ||
            Number[0] + Number[3] + Number[6] == 300 ||
            Number[1] + Number[4] + Number[7] == 300 ||
            Number[2] + Number[5] + Number[8] == 300 ||
            Number[0] + Number[4] + Number[8] == 300 ||
            Number[2] + Number[4] + Number[6] == 300)
        {
            Debug.Log("패배");
            OX_Reset();
        }
    }
    private void User(int index)
    {
        if (Number[index] != User_OX && Number[index] != Com_OX)
        {
            Number[index] = User_OX;
            Number_Text[index].text = "O";
            OX_Button[index].image.color = Color.cyan;
        }
    }
    private void Computer()
    {
        Random_Number = UnityEngine.Random.Range(0, 9);
        if (Number[Random_Number] != User_OX && Number[Random_Number] != Com_OX)
        {
            Number[Random_Number] = Com_OX;
            Number_Text[Random_Number].text = "X";
            OX_Button[Random_Number].image.color = Color.red;

        }
        else
        {
            int k = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Number[i] == User_OX || Number[i] == Com_OX)
                {
                    k++;
                }
            }
            if(k != 9)
            {
                Computer();
            }
            else
            {
                Debug.Log("Computer 가 누를 수 있는 공간이 없습니다.");
                OX_Reset();
            }
        }
    }
    private void OX_Reset()
    {
        for (int i = 0; i < 9; i++)
        {
            Number[i] = 0;
            Number_Text[i].text = "";
            OX_Button[i].image.color = Color.yellow;
        }
    }
}
