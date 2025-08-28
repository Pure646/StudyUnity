using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox_Ctrl : MonoBehaviour
{
    public delegate void DLT_Response();        //<--- 델리게이트 데이터(타입)형 하나 선언
    DLT_Response DltMethod;                     //<--- 델리게이트 변수 선언(소켓 역할)
    // delegate 을 사용하는 이유는 재활용하기 위한.
    // 다음 활동으로 넘기기 위함.

    public Button m_Ok_Btn = null;
    public Button m_Close_Btn = null;
    public Button m_Cancel_Btn = null;
    public Text m_Contents_Text = null;

    private void Start()
    {
        if (m_Ok_Btn != null)
            m_Ok_Btn.onClick.AddListener(() =>              
            {
                if (DltMethod != null)
                    DltMethod();
                Destroy(gameObject);
            });

        if (m_Close_Btn != null)
            m_Close_Btn.onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        if (m_Cancel_Btn != null)
            m_Cancel_Btn.onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
    }

    public void InitMessage(string a_Mess, DLT_Response a_DltMtd = null)
    {
        m_Contents_Text.text = a_Mess;
        DltMethod = a_DltMtd;
    }
}
