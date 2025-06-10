using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    float m_MvX = 0.0f;         // �̵� ���� ����
    float m_MvSpeed = 7.0f;     // �̵� �ӵ�

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {
        //// ���� ȭ��ǥ�� ������ ��
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-2, 0, 0); // �������� �̵�
        //}

        //// ������ ȭ��ǥ�� ������ ��
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Translate(2, 0, 0); // ���������� �̵�
        //}

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // transform.Translate(-3 , 0  ,0);         // �������� '3' �����δ�.
            // �ӵ� = �Ÿ� / �ð� ---> �ӵ� * �ð� = �Ÿ�
            m_MvX = Time.deltaTime * (-1.0f * m_MvSpeed);
            transform.Translate(m_MvX, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_MvX = Time.deltaTime * m_MvSpeed;
            transform.Translate(m_MvX, 0.0f, 0.0f);
        }
        Vector3 a_vPos = transform.position;
        if(8.0f < a_vPos.x)
        {
            a_vPos.x = 8.0f;
        }
        if(a_vPos.x < -8.0f)
        {
            a_vPos.x = -8.0f;
        }
        transform.position = a_vPos;
    }
    public void LButtonDown()
    {
        transform.Translate(-2, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(2, 0, 0);
    }
}

