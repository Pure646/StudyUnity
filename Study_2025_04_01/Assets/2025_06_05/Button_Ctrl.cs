using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Button_Ctrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    CatController m_CatCtrl = null;
    void Start()
    {
        m_CatCtrl = FindFirstObjectByType<CatController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {   // 마우스 버튼을 누르는 순간 실행됨.
        if(m_CatCtrl == null)
        {
            return;
        }
        if(gameObject.name == "RButton")
        {   // 오른쪽 이동 버튼을 뗼 때 한번 발생되는 부분
            m_CatCtrl.m_IsRBtnDown = true;
        }
        else if(gameObject.name == "LButton")
        {   // 왼쪽 이동 버튼을 뗄 때 한번 발생되는 부분
            m_CatCtrl.m_IsLBtnDown = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {   // 마우스 버튼을 누르고 있다가 떼는 순간 실행됨.
        if (m_CatCtrl == null)
        {
            return;
        }
        if (gameObject.name == "RButton")
        {   // 오른쪽 이동 버튼을 뗼 때 한번 발생되는 부분
            m_CatCtrl.m_IsRBtnDown = false;
        }
        else if (gameObject.name == "LButton")
        {   // 왼쪽 이동 버튼을 뗄 때 한번 발생되는 부분
            m_CatCtrl.m_IsLBtnDown = false;
        }
    }

}
