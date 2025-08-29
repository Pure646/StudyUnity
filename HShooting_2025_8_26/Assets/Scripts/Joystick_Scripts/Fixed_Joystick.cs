using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fixed_Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{   // Interface = 추상 함수로만 이루어져 있다.
    public RectTransform m_Js_Background;
    public RectTransform m_Js_Handle;

    private Vector2 InputDirection;
    private float Js_Radius;
    private Hero_Ctrl m_RefHero = null;

    private void Start()
    {
        m_RefHero = FindObjectOfType<Hero_Ctrl>();

        Js_Radius = m_Js_Background.sizeDelta.x * 0.34f;
        m_Js_Handle.anchoredPosition = Vector2.zero;        // 핸들 초기화
        // 핸들 이미지를 로컬의 중심적으로 이동 시키겠다는 뜻
    }
    private void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        if (m_Js_Background != null)
            m_Js_Background.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        if (m_Js_Handle != null)
            m_Js_Handle.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)       // 마우스 왼쪽 버튼만
            return;

        Vector2 touchPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(         // ScreenPointToLocalPointInRectangle : 중점을 기준으로 현재 마우스 위치를 터치하면 위치가 나옴
            m_Js_Background, eventData.position, eventData.pressEventCamera, out touchPos);
        // Js_Background 조이스틱 배경 (ResctTransform) -- 이 안에서 좌표를 재계산하고 싶을 때 사용하는 함수
        // 1번 매개변수 m_Js_Background : 환산하고 싶을 로컬 좌표계 UI의 RectTransfrom 컴포넌트 객체 대입
        // 2번 매개변수 eventData.position : 마우스 좌표
        // 3번 매개변수 eventData.pressEventCamera : 터치를 감지할 때 쓰는 카메라
        //  (UI 는 보통 Canvas에 연결된 카메라)
        // 4번 매개변수 touchPos : 변환된 결과. 조이스틱 배경 기준의 위치
        //  (중심을 (0,0)으로  하는 로컬 좌표계로 변환된 값)

        Vector2 clampedPos = Vector2.ClampMagnitude(touchPos, Js_Radius);
        m_Js_Handle.anchoredPosition = clampedPos;
        InputDirection = clampedPos / Js_Radius;            // 벡터의 최대크기는 1.0f가 될 것임

        // 캐릭터 이동 처리
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
        m_Js_Handle.anchoredPosition = Vector2.zero;        // 핸들 초기화(원래 위치로...)
        // 핸들 이미지를 로컬의 중심점으로 이동 시키겠다는 뜻

        if (m_Js_Background != null)
            m_Js_Background.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
        if (m_Js_Handle != null)
            m_Js_Handle.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);

        // 캐릭터 이동 멈춤 처리
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
    }
}
