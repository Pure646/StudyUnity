using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController2 : MonoBehaviour
{
    private float rotSpeed = 0;     // 회전 속도
    private float m_MaxPower = 100;
    private float DownSpeed;

    bool IsRotate = false;

    public Image m_PwBarImg = null;
    public Text PwText = null;

    Game_Mgr m_GameMgr = null;
    private void Start()
    {
        Application.targetFrameRate = 60;       // 딱 한번 적용이 된다.
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
            return;         // 5개의 슬롯에 숫자값이 모두 채워졌다면... GameOver 상태임
        }
        if(IsRotate == false) // 룰렛이 멈춰 있고, 힘 조절 할 수 있는 상태
        {
            // 클릭하면 회전 속도를 설정한다.
            if (Input.GetMouseButton(0))        // 마우스를 누르고 있는 동안
            {
                // 마우스가 UI 위에 있다면...
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
            {   // 마우스를 누르고 있다가 손가락을 때는 순간
                IsRotate = true;
            }
        }
        else
        {
            // 회전 속도만큼 룰렛을 회전시킨다.   // 1초의 rotSpeed의 만큼 더한다.
            transform.Rotate(0, 0, this.rotSpeed);

            // 회전 속도를 점점 줄어든다.
            this.rotSpeed *= 0.95f;

            if (rotSpeed <= 0.1f)   // 룰렛이 멈춘 상태로 판단하겠다는 뜻
            {
                rotSpeed = 0.0f;    // 룰렛을 완전 멈춰주고
                IsRotate = false;   // 룰렛이 멈춘 모드로 바꿔 힘 조절 가능 상태로 만들어 줌

                // 바늘이 가리키고 있는 번호 확인
                GetCurNumber();
                
            }   // if(rotSpeed <= 0.1f) // 룰렛이 멈춘 상태로 판단하겠다는 뜻
        }

        m_PwBarImg.fillAmount = rotSpeed / m_MaxPower;
        PwText.text = (int)(m_PwBarImg.fillAmount * 100) + " / 100";
    }

    private void GetCurNumber() // 룰렛이 멈췄을 때 바늘이 가리키고 있는 숫자 값을 얻어오는 값
    {
        //transform.rotation.z                                                  // Quaternion 값
        float a_Angle = transform.eulerAngles.z; //0.0f ~359.999999f            // 보일러 각
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
