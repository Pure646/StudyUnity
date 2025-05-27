using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController2 : MonoBehaviour
{
    private float rotSpeed = 0;     // ȸ�� �ӵ�
    private float m_MaxPower = 100;
    private float DownSpeed;

    bool IsRotate = false;

    public Image m_PwBarImg = null;
    public Text PwText = null;

    Game_Mgr m_GameMgr = null;
    private void Start()
    {
        Application.targetFrameRate = 60;       // �� �ѹ� ������ �ȴ�.
        QualitySettings.vSyncCount = 0;

        //GameObject a_GMObj = GameObject.Find("GameMgr");
        //if(a_GMObj != null )
        //{
        //    m_GameMgr = a_GMObj.GetComponent<Game_Mgr>();
        //}
        m_GameMgr = FindObjectOfType<Game_Mgr>();
    }
    private void Update()
    {
        if(m_GameMgr.NumberTexts.Length <= m_GameMgr.m_NumCount)
        {
            return;         // 5���� ���Կ� ���ڰ��� ��� ä�����ٸ�... GameOver ������
        }
        if(IsRotate == false) // �귿�� ���� �ְ�, �� ���� �� �� �ִ� ����
        {
            // Ŭ���ϸ� ȸ�� �ӵ��� �����Ѵ�.
            if (Input.GetMouseButton(0))        // ���콺�� ������ �ִ� ����
            {
                // ���콺�� UI ���� �ִٸ�...
                if(Game_Mgr.IsPointerOverUIObject() == true)
                {
                    return;
                }
                this.rotSpeed += (Time.deltaTime * 50.0f);
                if (m_MaxPower < rotSpeed)
                {
                    rotSpeed = m_MaxPower;
                }
            }

            if(Input.GetMouseButtonUp(0))
            {   // ���콺�� ������ �ִٰ� �հ����� ���� ����
                IsRotate = true;
            }
        }
        else
        {
            // ȸ�� �ӵ���ŭ �귿�� ȸ����Ų��.   // 1���� rotSpeed�� ��ŭ ���Ѵ�.
            transform.Rotate(0, 0, this.rotSpeed);

            // ȸ�� �ӵ��� ���� �پ���.
            this.rotSpeed *= 0.95f;

            if (rotSpeed <= 0.1f)   // �귿�� ���� ���·� �Ǵ��ϰڴٴ� ��
            {
                rotSpeed = 0.0f;    // �귿�� ���� �����ְ�
                IsRotate = false;   // �귿�� ���� ���� �ٲ� �� ���� ���� ���·� ����� ��

                // �ٴ��� ����Ű�� �ִ� ��ȣ Ȯ��
                GetCurNumber();
                
            }   // if(rotSpeed <= 0.1f) // �귿�� ���� ���·� �Ǵ��ϰڴٴ� ��
        }

        m_PwBarImg.fillAmount = rotSpeed / m_MaxPower;
        PwText.text = (int)(m_PwBarImg.fillAmount * 100) + " / 100";
    }

    private void GetCurNumber() // �귿�� ������ �� �ٴ��� ����Ű�� �ִ� ���� ���� ������ ��
    {
        //transform.rotation.z                                                  // Quaternion ��
        float a_Angle = transform.eulerAngles.z; //0.0f ~359.999999f            // ���Ϸ� ��
        int a_Num = 0;

        if (17.5f <= a_Angle && a_Angle < 54.5f)
        {
            a_Num = 8;
        }
        else if (54.5f <= a_Angle && a_Angle < 90.0f)
        {
            a_Num = 9;
        }
        else if (90.0f <= a_Angle && a_Angle < 125.5f)
        {
            a_Num = 0;
        }
        else if (125.5f <= a_Angle && a_Angle < 162.0f)
        {
            a_Num = 1;
        }
        else if (162.0f <= a_Angle && a_Angle < 198.0f)
        {
            a_Num = 2;
        }
        else if (198.0f <= a_Angle && a_Angle < 234.0f)
        {
            a_Num = 3;
        }
        else if (234.0f <= a_Angle && a_Angle < 270.0f)
        {
            a_Num = 4;
        }
        else if (270.0f <= a_Angle && a_Angle < 306.0f)
        {
            a_Num = 5;
        }
        else if (306.0f <= a_Angle && a_Angle < 342.0f)
        {
            a_Num = 6;
        }
        else
        {
            a_Num = 7;
        }

        if(m_GameMgr != null)
        {
            m_GameMgr.SetNumber(a_Num);
        }
    }
}
