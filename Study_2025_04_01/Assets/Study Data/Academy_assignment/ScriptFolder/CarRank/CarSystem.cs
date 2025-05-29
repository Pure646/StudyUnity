using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    private float CarSpeed = 0;
    private Vector2 StartPos;
    private Vector2 EndPos;
    private float StopCarSpeed = 0.0001f;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.StartPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            this.EndPos = Input.mousePosition;
            float swipeLength = this.EndPos.x - this.StartPos.x;
            
            if(swipeLength > 0)
            {
                this.CarSpeed = swipeLength / 700.0f;
            }
            else
            {
                this.CarSpeed = 0;
            }
        }
        transform.Translate(this.CarSpeed, 0, 0);
        this.CarSpeed *= 0.98f;
    }
}
