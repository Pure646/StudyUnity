using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Ctrl : MonoBehaviour
{
    [HideInInspector] public Hero_Ctrl m_RefHero = null;

    float m_MoveSpeed = 4.0f;
    float m_MagnetSpeed = 9.0f;
    Vector3 m_MoveDir;
    Vector3 m_CurPos;           //��ġ ���� ����

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f); //10�ʳ��� ���� ���ϸ� �ı��ǰ� ó��
    }

    // Update is called once per frame
    void Update()
    {
        bool isManet = false;
        if (m_RefHero != null)
        {
            m_MoveDir = m_RefHero.transform.position - transform.position;
            m_MoveDir.z = 0.0f;
            if (m_MoveDir.magnitude <= 3.0f)
            {
                m_MoveDir.Normalize();
                transform.position += m_MoveDir * Time.deltaTime * m_MagnetSpeed;
                isManet = true;
            }
        }//if(m_RefHero != null)

        if (isManet == false)
            transform.position += Vector3.left * Time.deltaTime * m_MoveSpeed;

        //������ ȭ�� ������ ����� ������ �ֱ�
        //m_CurPos = Camera.main.WorldToViewportPoint(transform.position);
        //if (m_CurPos.x < -0.1f)
        if(transform.position.x < CamResol.m_VpWMin.x - 1.0f)
        {
            Destroy(gameObject);
        }

    }//void Update()
}
