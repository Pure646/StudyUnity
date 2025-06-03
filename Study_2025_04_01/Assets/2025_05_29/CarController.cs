using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed = 0;
    private Vector2 startPos;
    private AudioSource audio;
    private GameDirector m_GDirector;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        m_GDirector = FindObjectOfType<GameDirector>();
    }

    private void Update()
    {
        if (GameDirector.s_State == GameStat.Ready)
        {   // 자동차가 멈춰 있을 때만, 힘 조절 가능 하도록...

            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition; // Input.mousePosition = 마우스 위치 좌표를 알수 있다.
            }
            else if (Input.GetMouseButtonUp(0))
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

                GameDirector.s_State = GameStat.MoveIng;
            }
        }
        else if (GameDirector.s_State == GameStat.MoveIng)
        {
            transform.Translate(this.speed, 0, 0);      // 이동
            this.speed *= 0.98f;                        // 감속

            if(this.speed < 0.0005f)    // 자동차가 멈췄다고 판단
            {
                this.speed = 0.0f;
                GameDirector.s_State = GameStat.Ready;

                // 지금 플레이어가 끝난 유저의 기록을 저장해 준다.
                //GameDirector a_GameDrct = null;
                //GameObject a_GDrctObject = GameObject.Find("GameDirector");
                //if(a_GDrctObject != null)
                //{
                //    a_GameDrct = a_GDrctObject.GetComponent<GameDirector>();
                //}
                //if(a_GameDrct != null)
                //{
                //    a_GameDrct.RecordLength();
                //}
                //GameDirector a_GameDrct = GameObject.FindObjectOfType<GameDirector>();      //GameDirector 가 붙어있는 Script를 찾는다.
                //if(a_GameDrct != null)
                //    a_GameDrct.RecordLength();

                // 플레이어의 깃발까지의 길이를 기록
                m_GDirector.RecordLength();

                // 다음번 플레이어를 위해서 자동차를 처음 위치로 돌려놓기
                this.transform.position = new Vector3(-7f, -3.7f, 0.0f);
            }
        }
    }
}
