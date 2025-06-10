using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : MonoBehaviour
{
    GameObject player;
    [HideInInspector] public float m_DownSpeed = -0.1f;

    private void Start()
    {
        this.player = GameObject.Find("player");   
    }
    private void Update()
    {
        // 플레임마다 등속으로 낙하시킨다.
        transform.Translate(0, m_DownSpeed, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;        // 물고기 중심 좌표
        Vector2 p2 = this.player.transform.position;        // 플레이어 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;                // 중점과 중점의 거리
        float r1 = 0.5f;                        // 물고기의 충돌 반경
        float r2 = 1.0f;                        // 플레이어의 충돌 반경
        if(d < r1 + r2)
        {
            // 충돌하면 물고기를 소멸시킨다.
            Destroy(gameObject);

            // 감독 스크립트에 플레이어와 물고기가 충돌 했다고 전달한다.
            GameObject director = GameObject.Find("CatDirector");
            director.GetComponent<CatDirector>().Add_Gold();

        }

    }
}
