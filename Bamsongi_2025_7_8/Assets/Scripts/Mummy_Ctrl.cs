using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy_Ctrl : MonoBehaviour
{
    Transform playerTr;
    [HideInInspector] public float m_MoveVelocity = 13.0f;          // �ʴ� �̵� �ӵ�
    // �ܺο��� �����ϰ� �Ͱ�, [HideInInspector] �� ����ؼ� ������ ���� ���ؼ�

    private void Start()
    {
        // playerTr = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerTr = Camera.main.transform;
    }

    private void Update()
    {
        // --- ���� �̵� ����
        Vector3 a_MoveDir = playerTr.position - transform.position;

        transform.forward = a_MoveDir.normalized;
        Vector3 a_StepVec = transform.forward * m_MoveVelocity * Time.deltaTime;        
        transform.Translate(a_StepVec, Space.World);            // ���� ��ǥ��� ����� �ض�.

        float a_CacPosY = Game_Mgr.Inst.m_RefMap.SampleHeight(transform.position);
        transform.position = new Vector3(transform.position.x, a_CacPosY, transform.position.z);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = 0f;
        transform.rotation = Quaternion.Euler(rot);
    }

}
