using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Flexible_Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform m_Js_Background;
    public RectTransform m_Js_Handle;

    Vector2 InputDirection;
    float Js_Radius;
    Vector3 m_OriginPos = Vector3.zero;

    Hero_Ctrl m_RefHero = null;

    private void Start()
    {
        m_RefHero = FindObjectOfType<Hero_Ctrl>();

        m_OriginPos = m_Js_Background.transform.position;
        Js_Radius = m_Js_Background.sizeDelta.x * 0.34f;
        if(Joystick_Mgr.Inst.m_JoyStickType == JoyStickType.FlexibleOnOff)
        {
            m_Js_Background.gameObject.SetActive(false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        m_Js_Background.gameObject.SetActive(true);
        m_Js_Background.position = eventData.position;          // 마우스의 현재 위치
        m_Js_Handle.anchoredPosition = Vector2.zero;            // 부모 RectTransfrom의 Pivot + Anchors 기준 위치

        if (m_Js_Background != null)
            m_Js_Background.gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
        if (m_Js_Handle != null)
            m_Js_Handle.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        Vector2 touchPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            m_Js_Background, eventData.position, eventData.pressEventCamera, out touchPos);
        Vector2 clampedPos = Vector2.ClampMagnitude(touchPos, Js_Radius);
        m_Js_Handle.anchoredPosition = clampedPos;
        InputDirection = clampedPos / Js_Radius;            // 벡터의 최대 크기는 1.0f가 될 것임

        // 캐릭터 이동처리
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
        // 캐릭터 이동 처리
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
        m_Js_Background.transform.position = m_OriginPos;
        m_Js_Handle.anchoredPosition = Vector2.zero;            // 핸들 초기화 ( 원래 위치로...)

        if (m_Js_Background != null)
            m_Js_Background.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
        if (m_Js_Handle != null)
            m_Js_Handle.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);

        if(Joystick_Mgr.Inst.m_JoyStickType == JoyStickType.FlexibleOnOff)
        {
            m_Js_Background.gameObject.SetActive(false);
        }

        // 캐릭터 이동 멈춤 처리
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
    }
}
