using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum City        // enum �� �ǳʶ���� + �������� ���ִ°� ����.
{
    Seoul,
    Inchenon,
    Busan,
    Gwangju,
    Jeju,
    Shinchon,
    Count
}

public class Test_04_24_01 : MonoBehaviour
{
    private void Start()
    {
        City MyCity = City.Busan;
        Debug.Log("MyCity : " + MyCity + " : Index(" + (int)MyCity + ")");
        Debug.Log("Shinchon : " + City.Shinchon);
    }
}
