using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCtrl : MonoBehaviour
{
    GameObject player;
    float speed = 1.0f;     // 1�ʿ� 1m�� �����̰� �Ѵٴ� �ӵ�
    float distanceItv = 8.0f;       // ���ΰ����� �Ÿ��� 8m �̻� �������� �ʵ���...

    private void Start()
    {
        player = GameObject.Find("cat");
    }

    private void Update()
    {
        // Player�� �Ÿ��� �ʹ� �� ��� ����
        float a_FollowHeight = player.transform.position.y - distanceItv;
        if (transform.position.y < a_FollowHeight)
            transform.position = new Vector3(0.0f, a_FollowHeight, 0.0f);
        else 
            transform.Translate(new Vector3(0.0f, speed * Time.deltaTime * 2, 0.0f));
    }
}
