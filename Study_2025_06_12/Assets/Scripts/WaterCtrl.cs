using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCtrl : MonoBehaviour
{
    GameObject player;
    float speed = 1.0f;     // 1초에 1m를 움직이게 한다는 속도
    float distanceItv = 8.0f;       // 주인공과의 거리가 8m 이상 벌어지지 않도록...

    private void Start()
    {
        player = GameObject.Find("cat");
    }

    private void Update()
    {
        // Player와 거리가 너무 먼 경우 보정
        float a_FollowHeight = player.transform.position.y - distanceItv;
        if (transform.position.y < a_FollowHeight)
            transform.position = new Vector3(0.0f, a_FollowHeight, 0.0f);
        else 
            transform.Translate(new Vector3(0.0f, speed * Time.deltaTime * 2, 0.0f));
    }
}
