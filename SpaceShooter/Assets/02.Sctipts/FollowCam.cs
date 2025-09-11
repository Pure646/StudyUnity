using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;          // 추적할 타깃 게임오브젝트의 Transfrom 변수
    public float dist = 10.0f;           // 카메라와의 일정 거리
    public float height = 3.0f;         // 카메라의 높이 설정
    public float dampTrace = 20.0f;     // 부드러운 추적을 위한 변수

    private Vector3 m_PlayerVec = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        dist = 3.4f;
        height = 2.8f;
    }
    private void LateUpdate()
    {
        m_PlayerVec = targetTr.position;
        m_PlayerVec.y += 1.2f;

        transform.position = Vector3.Lerp(transform.position, 
            targetTr.position - (targetTr.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);

        // 카메라가 타깃 게임오브젝트를 바라보게 설정
        transform.LookAt(m_PlayerVec);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
