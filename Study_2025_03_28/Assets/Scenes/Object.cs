using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int Add_Number = 0;
    private int number = 0;
    void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            Add_Number = number + i;
            Debug.Log($"{Add_Number} = {number} + {i}");
            number = Add_Number;
        }
    }
    
}
