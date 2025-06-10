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
        // �����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, m_DownSpeed, 0);

        // ȸ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;                // ȭ���� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position;    // �÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;
        if (d < r1 + r2) 
        {
            GameObject director = GameObject.Find("CatDirector");
            director.GetComponent<CatDirector>().DecreaseHp();
            // �浹�� ���� ȭ���� ġ���.
            Destroy(gameObject);
        }
    }
}

