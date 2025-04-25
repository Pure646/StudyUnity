using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListList : MonoBehaviour
{
    private List<int> ListInt = new List<int>();
    private List<int> List_Int = new List<int> { 0, 3, 1, 3, 4 };
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            ListInt.Add(i);
            ListInt[i] = i;
            //Debug.Log(ListInt[i]);
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(ListInt[2]);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            ListInt.RemoveAt(2);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            for(int i = 0; i < ListInt.Count;i++)
            {
                Debug.Log(ListInt[i]);
            }
        }
    }
}
