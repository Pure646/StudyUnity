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
    {   // ���콺 ��ư�� ������ ���� �����.
        if(m_CatCtrl == null)
        {
            return;
        }
        if(gameObject.name == "RButton")
        {   // ������ �̵� ��ư�� �� �� �ѹ� �߻��Ǵ� �κ�
            m_CatCtrl.m_IsRBtnDown = true;
        }
        else if(gameObject.name == "LButton")
        {   // ���� �̵� ��ư�� �� �� �ѹ� �߻��Ǵ� �κ�
            m_CatCtrl.m_IsLBtnDown = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {   // ���콺 ��ư�� ������ �ִٰ� ���� ���� �����.
        if (m_CatCtrl == null)
        {
            return;
        }
        if (gameObject.name == "RButton")
        {   // ������ �̵� ��ư�� �� �� �ѹ� �߻��Ǵ� �κ�
            m_CatCtrl.m_IsRBtnDown = false;
        }
        else if (gameObject.name == "LButton")
        {   // ���� �̵� ��ư�� �� �� �ѹ� �߻��Ǵ� �κ�
            m_CatCtrl.m_IsLBtnDown = false;
        }
    }

}
