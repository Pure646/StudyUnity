using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy_Ctrl : MonoBehaviour
{
    Transform playerTr;
    [HideInInspector] public float m_MoveVelocity = 13.0f;          // 초당 이동 속도
    // 외부에서 접근하고 싶고, [HideInInspector] 를 사용해서 노출을 막기 위해서

    private void Start()
    {
        // playerTr = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerTr = Camera.main.transform;
    }

    private void Update()
    {
        // --- 추적 이동 구현
        Vector3 a_MoveDir = playerTr.position - transform.position;

        transform.forward = a_MoveDir.normalized;
        Vector3 a_StepVec = transform.forward * m_MoveVelocity * Time.deltaTime;        
        transform.Translate(a_StepVec, Space.World);            // 월드 좌표계로 계산을 해라.

        float a_CacPosY = Game_Mgr.Inst.m_RefMap.SampleHeight(transform.position);
        transform.position = new Vector3(transform.position.x, a_CacPosY, transform.position.z);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = 0f;
        transform.rotation = Quaternion.Euler(rot);
    }

}
