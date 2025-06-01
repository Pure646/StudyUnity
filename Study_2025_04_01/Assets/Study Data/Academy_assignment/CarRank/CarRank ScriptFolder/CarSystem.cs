using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    public float CarSpeed;

    private Vector2 StartPos;
    private Vector2 EndPos;
    public bool stop;           // true ÀÌ¸é ¸ØÃá°ÍÀÌ°í ¾Æ´Ï¸é false

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = new Vector2(-7f, -3.65f);
            this.StartPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            this.EndPos = Input.mousePosition;
            float swipeLength = this.EndPos.x - this.StartPos.x;
            
            if(swipeLength > 0)
            {
                this.CarSpeed = swipeLength / 1000.0f;
            }
            else
            {
                this.CarSpeed = 0;
            }
        }

        if (this.CarSpeed < 0.001f && stop == false)
        {
            stop = true;
            this.CarSpeed = 0;
        }
        else if (this.CarSpeed >= 0.001f)
        {
            gameObject.transform.Translate(this.CarSpeed, 0, 0);
            this.CarSpeed *= 0.98f;
            stop = false;
        }
    }
}
