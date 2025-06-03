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
        {   // �ڵ����� ���� ���� ����, �� ���� ���� �ϵ���...

            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition; // Input.mousePosition = ���콺 ��ġ ��ǥ�� �˼� �ִ�.
            }
            else if (Input.GetMouseButtonUp(0))
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

                GameDirector.s_State = GameStat.MoveIng;
            }
        }
        else if (GameDirector.s_State == GameStat.MoveIng)
        {
            transform.Translate(this.speed, 0, 0);      // �̵�
            this.speed *= 0.98f;                        // ����

            if(this.speed < 0.0005f)    // �ڵ����� ����ٰ� �Ǵ�
            {
                this.speed = 0.0f;
                GameDirector.s_State = GameStat.Ready;

                // ���� �÷��̾ ���� ������ ����� ������ �ش�.
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
                //GameDirector a_GameDrct = GameObject.FindObjectOfType<GameDirector>();      //GameDirector �� �پ��ִ� Script�� ã�´�.
                //if(a_GameDrct != null)
                //    a_GameDrct.RecordLength();

                // �÷��̾��� ��߱����� ���̸� ���
                m_GDirector.RecordLength();

                // ������ �÷��̾ ���ؼ� �ڵ����� ó�� ��ġ�� ��������
                this.transform.position = new Vector3(-7f, -3.7f, 0.0f);
            }
        }
    }
}
