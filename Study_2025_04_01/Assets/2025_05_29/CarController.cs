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
            this.startPos = Input.mousePosition; // Input.mousePosition = ���콺 ��ġ ��ǥ�� �˼� �ִ�.
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // ���콺 ��ư���� �հ����� ������ �� ��ǥ
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            // �������� ���̸� ó�� �ӵ��� �����Ѵ�.
            this.speed = swipeLength / 500.0f;

            // ȿ������ ����Ѵ�.
            audio.Play();

            //.mp3 ��� ���ǿ� ���� ���ȴ�.
            //.wav �Ҹ� ����� ���� ���ȴ�.
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
