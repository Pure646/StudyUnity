using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject fishPrefab;
    private float span = 1f;          // 스폰 시간
    private float delta = 0f;
    private int ratio = 3;                          // 물고기의 스폰 확률
    private float m_DwSpeedCtrl = -0.1f;            // 전체 낙하 속도를 제어하기 위한 변수
    private void Start()
    {
        
    }
    private void Update()
    {
        m_DwSpeedCtrl -= (Time.deltaTime * 0.005f);     // 낙하 속도 점점 빨라지게 하기...
        if (m_DwSpeedCtrl < -0.3f)
        {
            m_DwSpeedCtrl = -0.3f;
        }
        span -= (Time.deltaTime * 0.03f);               // 스폰 주기 점점 짧아지게 하기...
        if(span < 0.1f)
        {
            span = 0.1f;
        }
        // --- 난이도 설정
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = null;
            int dice = Random.Range(1, 11);     // 1 ~ 10 랜덤값 발생
            if(dice <= this.ratio)              // 30%
            {
                go = Instantiate(fishPrefab);
                go.GetComponent<fishController>().m_DownSpeed = m_DwSpeedCtrl;
            }
            else                                // 70%
            {
                go = Instantiate(arrowPrefab);  // 화살 스폰
                go.GetComponent<ArrowController>().m_DownSpeed = m_DwSpeedCtrl;
            }

            int px = Random.Range(-8, 9);       // -8 ~ 8 까지의 값
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
