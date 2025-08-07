using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HtItem_Ctrl : MonoBehaviour
{
    private int m_DirVecX = 1;                  // 날아갈 X 방향 값
    private int m_DirVecY = 1;                  // 날아갈 Y 방향 값
    private Vector3 m_DirVec;                   
    private float m_MoveSpeed = 9.9f;           // 날아 다니는 속도

    private void Start()
    {
        m_DirVec = new Vector3(m_DirVecX, m_DirVecY, 0.0f);
        Destroy(gameObject, 10.0f);
    }
    private void Update()
    {
        transform.position += (m_DirVec * Time.deltaTime * m_MoveSpeed);
        if(transform.position.x < CamResol.m_VpWMin.x + 0.5f ||
            CamResol.m_VpWMax.x - 0.5f < transform.position.x)
        {
            m_DirVecX = -m_DirVecX;
        }
        if (transform.position.y < CamResol.m_VpWMin.y + 0.5f ||
            CamResol.m_VpWMax.y - 0.5f < transform.position.y) 
        {
            m_DirVecY = -m_DirVecY;
        }
        m_DirVec.x = m_DirVecX;
        m_DirVec.y = m_DirVecY;
        m_DirVec.z = 0.0f;
        m_DirVec.Normalize();
    }
}
