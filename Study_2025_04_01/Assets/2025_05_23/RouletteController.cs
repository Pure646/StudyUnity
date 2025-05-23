using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    private float rotSpeed = 0;     // 회전 속도

    private float DownSpeed;
    private void Start()
    {
        // 프레임레이트를 60으로 고정 (어떤 컴퓨터이여도 FPS 를 고정시킨다.)
        Application.targetFrameRate = 60;       // 딱 한번 적용이 된다.

        // 모니터 주사율(플레임)이 다른 컴퓨터일 경우 캐릭터 조작시 빠르게 움직일 수 있다.
        // 모니터의 프레임을 설정한다.  // 0이면 모니터의 주사율의 영향을 받지 않게 한다.
        QualitySettings.vSyncCount = 0;
    }
    private void Update()
    {
        
        // 클릭하면 회전 속도를 설정한다.
        if(Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 20;
            //for (int i = 11; i > 0; i--)
            //{
            //    this.rotSpeed = i;
            //    if(i == 1)
            //    {
            //        i = 11;
            //    }
            //    else if (Input.GetMouseButtonDown(1))
            //    {
            //        i = 0;
            //    }
            //    if(i == 0)
            //    {
            //        break;
            //    }
            //}
        }
        // 회전 속도만큼 룰렛을 회전시킨다.   // 1초의 rotSpeed의 만큼 더한다.
        transform.Rotate(0, 0, this.rotSpeed);

        // 회전 속도를 점점 줄어든다.
        this.rotSpeed *= 0.95f;
    }
}
