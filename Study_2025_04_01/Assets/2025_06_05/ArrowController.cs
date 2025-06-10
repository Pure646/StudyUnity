using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private GameObject player;
    public float m_DownSpeed;
    private void Start()
    {
        this.player = GameObject.Find("player");
    }
    private void Update()
    {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, m_DownSpeed, 0);

        // 회면 밖으로 나오면 오브젝트를 소멸시킨다.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;                // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position;    // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;
        if (d < r1 + r2) 
        {
            GameObject director = GameObject.Find("CatDirector");
            director.GetComponent<CatDirector>().DecreaseHp();
            // 충돌한 경우는 화살을 치운다.
            Destroy(gameObject);
        }
    }
}

