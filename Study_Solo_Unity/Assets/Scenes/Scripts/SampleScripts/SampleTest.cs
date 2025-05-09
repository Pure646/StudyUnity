using UnityEngine;
using System;

public class SampleTest : MonoBehaviour
{
    private enum Monster
    {
        None = 0,
        Zombie = 1,
        Skeleton = 2,
        mutated_Zombie = 3,
        Golem = 4,
        witch =5,
    }
    // 몬스터 번호로 이름 추출 하는 방법 : (Monster)Monster_Number

    private float Com_Number;
    private float User_Number;
    private float UserHp;

    private float timeset;
    private bool timestop;

    private int Monster_Number;
    private int[] Count;
    private int nowCount;
    private void Start()
    {
        Count = new int[3];
        for(int i = 0; i < Count.Length; i++)
        {
            Count[i] = 0;
        }
        UserHp = 100;
        nowCount = 0;
        Monster_Number = 1;
        Debug.Log($"현재 상대는 {(Monster)Monster_Number} 입니다.");
    }
    private void Update()
    {
        Timeseting();
        if(UserHp > 0)
        {
            if(Input.GetKeyDown(KeyCode.Space) && timestop == true && Count[0] == nowCount)
            {
                timeset = 2;
                Dice();
            }
            if (Count[0] > nowCount && timestop == true)
            {
                timeset = 2;
                Monster_Number = Count[0] + 1;
                nowCount = Count[0];
                Debug.Log($"현재 상대는 {(Monster)Monster_Number} 입니다.");
            }
        }
        else
        {
            Debug.Log("Game Over");
            UserHp = 100;
        }
    }
    private void World()
    {

    }
    private void Timeseting()
    {
        if(timeset > 0)
        {
            timeset -= Time.deltaTime;
            timestop = false;
        }
        else if(timeset <= 0 && timestop == false)
        {
            timestop = true;
            Debug.Log("---------------------------");
        }
    }
    private void Dice()
    {
        ComDice();
        UserDice();
        if(User_Number < Com_Number)
        {
            UserHp = UserHp + (User_Number - Com_Number);
            Debug.Log($"UserHp : {UserHp} , Damaged : {User_Number - Com_Number}");
            Debug.Log("패배!!!");
            Count[1] += 1;
        }
        else if(User_Number == Com_Number)
        {
            Debug.Log("무승부");
            Count[2] += 1;
            Dice();
        }
        else
        {
            Debug.Log($"UserHp : {UserHp}");
            Debug.Log("승리!!!");
            Count[0] += 1;
        }
    }
    private void ComDice()
    {
        Com_Number = UnityEngine.Random.Range(1, Monster_Number + 1);
        Debug.Log($"Com_Number : {Com_Number}");
    }
    private void UserDice()
    {
        User_Number = UnityEngine.Random.Range(1, 6);
        Debug.Log($"User_Number : {User_Number}");
    }
}
