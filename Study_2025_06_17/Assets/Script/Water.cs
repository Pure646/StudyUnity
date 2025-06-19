using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void Update()
    {
        if(PointArrow.HealthPoint > 0)
        {
            gameObject.transform.Translate(Vector2.up * Time.deltaTime * 1.5f);
        }
    }
}
