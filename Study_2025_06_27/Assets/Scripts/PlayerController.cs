using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;

    float moveSpeed = 10.0f;    // 이동속도
    Vector3 moveDir = Vector3.zero;

    //---카메라 회전을 위한 변수
    float rotSpeed = 350.0f;
    Vector3 m_CacVec = Vector3.zero;

    //--- 높이값 찾기 위한 변수
    public Terrain m_RefMap = null;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetMouseButton(1) == true)
        {
            m_CacVec = transform.eulerAngles;

            m_CacVec.y += (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse X"));
            m_CacVec.x -= (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse Y"));

            if (180.0f < m_CacVec.x && m_CacVec.x < 330.0f)
                m_CacVec.x = 330.0f;
            if (30.0f < m_CacVec.x && m_CacVec.x <= 180.0f) 
                m_CacVec.x = 30.0f;

            transform.eulerAngles = m_CacVec;
        }

        h = Input.GetAxis("Horizontal");            // -1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");              // -1.0f ~ 1.0f

        moveDir = (Vector3.forward * v) + (Vector3.right * h);
        if (1.0f < moveDir.magnitude)
            moveDir.Normalize();

        transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);

        //--- 캐릭터 높이값 조정
        transform.position = new Vector3(transform.position.x, 
            m_RefMap.SampleHeight(transform.position) + 5.0f,
            transform.position.z);
    }
}
