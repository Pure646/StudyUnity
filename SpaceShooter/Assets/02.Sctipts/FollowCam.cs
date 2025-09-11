using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;          // ������ Ÿ�� ���ӿ�����Ʈ�� Transfrom ����
    public float dist = 10.0f;           // ī�޶���� ���� �Ÿ�
    public float height = 3.0f;         // ī�޶��� ���� ����
    public float dampTrace = 20.0f;     // �ε巯�� ������ ���� ����

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

        // ī�޶� Ÿ�� ���ӿ�����Ʈ�� �ٶ󺸰� ����
        transform.LookAt(m_PlayerVec);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
