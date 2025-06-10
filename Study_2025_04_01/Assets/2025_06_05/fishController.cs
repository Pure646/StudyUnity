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
        // �÷��Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, m_DownSpeed, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // �浹 ����
        Vector2 p1 = transform.position;        // ����� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position;        // �÷��̾� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;                // ������ ������ �Ÿ�
        float r1 = 0.5f;                        // ������� �浹 �ݰ�
        float r2 = 1.0f;                        // �÷��̾��� �浹 �ݰ�
        if(d < r1 + r2)
        {
            // �浹�ϸ� ����⸦ �Ҹ��Ų��.
            Destroy(gameObject);

            // ���� ��ũ��Ʈ�� �÷��̾�� ����Ⱑ �浹 �ߴٰ� �����Ѵ�.
            GameObject director = GameObject.Find("CatDirector");
            director.GetComponent<CatDirector>().Add_Gold();

        }

    }
}
