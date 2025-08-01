using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamResol : MonoBehaviour
{
    public GameObject UI_MaskGroup = null;

    // 뷰포트의 월드좌표 VpW : Viewport To World
    public static Vector3 m_VpWMin = new Vector3(-10.0f, -5.0f, 0.0f);
    public static Vector3 m_VpWMax = new Vector3(10.0f, 5.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        Camera a_Cam = GetComponent<Camera>();
        Rect rect = a_Cam.rect;
        float scaleHeight = ((float)Screen.width / Screen.height) /
                                ((float)16 / 9);
        float scaleWidth = 1.0f / scaleHeight;

        if (scaleHeight < 1.0f)
        {
            rect.height = scaleHeight;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1.0f - scaleWidth) / 2.0f;
        }

        a_Cam.rect = rect;

        if (UI_MaskGroup != null)
            UI_MaskGroup.SetActive(true);

        // ---스크린의 월드 좌표 구하기
        Vector3 a_VpMin = new Vector3(0.0f, 0.0f, 0.0f);
        m_VpWMin = a_Cam.ViewportToWorldPoint(a_VpMin);
        // 카메라 화면 좌측하단 (화면 최소값) 코너의 월드 좌표

        Vector3 a_VpMax = new Vector3(1.0f, 1.0f, 1.0f);
        m_VpWMax = a_Cam.ViewportToWorldPoint(a_VpMax);
        // 카메라 화면 우측상단 (화면 최대값) 코너의 월드 좌표
       
    }
}
