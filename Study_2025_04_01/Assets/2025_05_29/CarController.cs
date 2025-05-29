using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed = 0;
    private Vector2 startPos;
    private Vector2 tutorial;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition; // Input.mousePosition = 마우스 위치 좌표를 알수 있다.
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // 마우스 버튼에서 손가락을 떼었을 때 좌표
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            // 스와이프 길이를 처음 속도로 변경한다.
            this.speed = swipeLength / 500.0f;

            // 효과음을 재생한다.
            audio.Play();

            //.mp3 배경 음악에 많이 사용된다.
            //.wav 소리 재생에 많이 사용된다.
        }
        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;

        if (Input.GetKey(KeyCode.K))
        {
            this.tutorial = Input.mousePosition;
            Debug.Log(this.tutorial);
        }
    }
}
