using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;

    float moveSpeed = 10.0f; //이동속도
    Vector3 moveDir = Vector3.zero; //이동방향

    //--- 카메라 회전을 위한 변수
    float rotSpeed = 350.0f;
    Vector3 m_CacVec = Vector3.zero;
    //--- 카메라 회전을 위한 변수

    //--- 높이값 찾기 위한 변수
    public Terrain m_RefMap = null;
    //--- 높이값 찾기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--- 카메라 회전 구현 부분
        if (Input.GetMouseButton(1) == true) //마우스 오른쪽 버튼 누르고 있는 동안
        {
            m_CacVec = transform.eulerAngles;

            m_CacVec.y += (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse X"));  // -1, 0, 1
            m_CacVec.x -= (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse Y"));  // -1, 0, 1

            if (180.0f < m_CacVec.x && m_CacVec.x < 340.0f)
                m_CacVec.x = 340.0f;

            if (12.0f < m_CacVec.x && m_CacVec.x <= 180.0f)
                m_CacVec.x = 12.0f;

            transform.eulerAngles = m_CacVec;
        }
        //--- 카메라 회전 구현 부분

        //--- 이동 구현 부분
        h = Input.GetAxis("Horizontal");    //-1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");      //-1.0f ~ 1.0f

        //1번 방법 전후좌우 이동 방향 벡터 계산
        moveDir = (Vector3.forward * v) + (Vector3.right * h);
        if (1.0f < moveDir.magnitude)
            moveDir.Normalize();

        transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);
        //1번 방법 전후좌우 이동 방향 벡터 계산 default값은 Space.Self
        //두번째 매개변수를 명시해주지 않을 경우 Space.Self

        ////2번 방법 월드 좌표계를 기준으로 누적시켜 이동시키는 방법
        //moveDir = (transform.forward * v) + (transform.right * h);
        //if (1.0f < moveDir.magnitude)
        //    moveDir.Normalize();

        //transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.World);
        ////2번 방법 월드 좌표계를 기준으로 누적시켜 이동시키는 방법

        ////3번 방법 직접 좌표를 누적시켜 이동시키는 방법
        //moveDir = (transform.forward * v) + (transform.right * h);
        //if (1.0f < moveDir.magnitude)
        //    moveDir.Normalize();

        //transform.position += moveDir * Time.deltaTime * moveSpeed;
        ////3번 방법 직접 좌표를 누적시켜 이동시키는 방법
        //속도 = 이동거리 / 시간 --> 속도 * 시간 = 이동거리 --> 시간 * 속도 = 이동거리

        //--- 캐릭터 높이값 조정
        transform.position = new Vector3(transform.position.x,
                                m_RefMap.SampleHeight(transform.position) + 5.0f,
                                transform.position.z);
        //--- 캐릭터 높이값 조정

    }//void Update()

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Game_Mgr.Inst.DecreaseHp();     // 주인공 하트 하나 감소 시키기
            Destroy(coll.gameObject);
        }
    }

    public bool IsMove()
    {
        if(h == 0 && v == 0)
        {
            return false;           // 멈춰 있다는 의미
        }
        return true;                // 이동 중이라는 의미
    }
}
