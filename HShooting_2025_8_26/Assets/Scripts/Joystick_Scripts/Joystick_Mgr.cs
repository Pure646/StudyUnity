using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum JoyStickType
{
    Fixed = 0,
    Flexible = 1,
    FlexibleOnOff = 2,
}

public class Joystick_Mgr : MonoBehaviour
{
    public JoyStickType m_JoyStickType = JoyStickType.Flexible;

    public GameObject m_JoystickPickPanel = null;
    public GameObject m_Js_Background = null;
    public GameObject m_Js_Handle = null;

    //--- 싱글턴 패턴
    public static Joystick_Mgr Inst = null;

    private void Awake()
    {
        Inst = this;
    }
    private void Start()
    {
        if (m_Js_Background == null || m_Js_Handle == null || m_JoystickPickPanel == null)
            return;
        if(m_JoyStickType == JoyStickType.Fixed)
        {
            m_JoystickPickPanel.SetActive(false);
            m_Js_Background.SetActive(true);
            m_Js_Background.GetComponent<Image>().raycastTarget = true;
        }
        else if(m_JoyStickType == JoyStickType.Flexible || m_JoyStickType == JoyStickType.FlexibleOnOff)
        {
            m_JoystickPickPanel.SetActive(true);
            if (m_JoyStickType == JoyStickType.FlexibleOnOff)
                m_Js_Background.SetActive(false);

            var VJoystickSc = m_Js_Background.GetComponent<Fixed_Joystick>();
            if (VJoystickSc != null)
                Destroy(VJoystickSc);           // 스크립드 자체를 제거함

            m_Js_Background.GetComponent<Image>().raycastTarget = false;
        }

    }
}
