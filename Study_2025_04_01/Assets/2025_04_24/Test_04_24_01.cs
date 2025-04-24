using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum City        // enum 은 건너띄더라도 + 형식으로 해주는게 좋다.
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
