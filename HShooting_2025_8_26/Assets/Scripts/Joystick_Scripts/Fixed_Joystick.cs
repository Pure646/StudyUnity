using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fixed_Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{   // Interface = �߻� �Լ��θ� �̷���� �ִ�.
    public RectTransform m_Js_Background;
    public RectTransform m_Js_Handle;

    private Vector2 InputDirection;
    private float Js_Radius;
    private Hero_Ctrl m_RefHero = null;

    private void Start()
    {
        m_RefHero = FindObjectOfType<Hero_Ctrl>();

        Js_Radius = m_Js_Background.sizeDelta.x * 0.34f;
        m_Js_Handle.anchoredPosition = Vector2.zero;        // �ڵ� �ʱ�ȭ
        // �ڵ� �̹����� ������ �߽������� �̵� ��Ű�ڴٴ� ��
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
        if (eventData.button != PointerEventData.InputButton.Left)       // ���콺 ���� ��ư��
            return;

        Vector2 touchPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(         // ScreenPointToLocalPointInRectangle : ������ �������� ���� ���콺 ��ġ�� ��ġ�ϸ� ��ġ�� ����
            m_Js_Background, eventData.position, eventData.pressEventCamera, out touchPos);
        // Js_Background ���̽�ƽ ��� (ResctTransform) -- �� �ȿ��� ��ǥ�� �����ϰ� ���� �� ����ϴ� �Լ�
        // 1�� �Ű����� m_Js_Background : ȯ���ϰ� ���� ���� ��ǥ�� UI�� RectTransfrom ������Ʈ ��ü ����
        // 2�� �Ű����� eventData.position : ���콺 ��ǥ
        // 3�� �Ű����� eventData.pressEventCamera : ��ġ�� ������ �� ���� ī�޶�
        //  (UI �� ���� Canvas�� ����� ī�޶�)
        // 4�� �Ű����� touchPos : ��ȯ�� ���. ���̽�ƽ ��� ������ ��ġ
        //  (�߽��� (0,0)����  �ϴ� ���� ��ǥ��� ��ȯ�� ��)

        Vector2 clampedPos = Vector2.ClampMagnitude(touchPos, Js_Radius);
        m_Js_Handle.anchoredPosition = clampedPos;
        InputDirection = clampedPos / Js_Radius;            // ������ �ִ�ũ��� 1.0f�� �� ����

        // ĳ���� �̵� ó��
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
        m_Js_Handle.anchoredPosition = Vector2.zero;        // �ڵ� �ʱ�ȭ(���� ��ġ��...)
        // �ڵ� �̹����� ������ �߽������� �̵� ��Ű�ڴٴ� ��

        if (m_Js_Background != null)
            m_Js_Background.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
        if (m_Js_Handle != null)
            m_Js_Handle.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 120);

        // ĳ���� �̵� ���� ó��
        if (m_RefHero != null)
            m_RefHero.SetJoyStickMv(InputDirection);
    }
}
