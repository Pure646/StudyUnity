using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {
        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0); // 왼쪽으로 이동
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0); // 오른쪽으로 이동
        }

        Vector3 a_vPos = transform.position;
        if(8.0f < a_vPos.x)
        {
            a_vPos.x = 8.0f;
        }
        if(a_vPos.x < -8.0f)
        {
            a_vPos.x = -8.0f;
        }
        transform.position = a_vPos;
    }
    public void LButtonDown()
    {
        transform.Translate(-2, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(2, 0, 0);
    }
}

