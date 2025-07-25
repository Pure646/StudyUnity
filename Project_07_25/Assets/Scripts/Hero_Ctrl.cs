using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero_Ctrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    private float moveSpeed = 7.0f;
    private Vector3 moveDir = Vector3.zero;
    // --- Ű���� �Է°� ���� ����.

    // ���ΰ� ȭ�� ������ ���� �� ������ ���� ���� ����
    private Vector3 HalfSize = Vector3.zero;
    private Vector3 m_CacCurPos = Vector3.zero;

    [SerializeField] private Image CharacterHp_bar;
    public static float CharacterHp = 1;

    private void Start()
    {
        CharacterHp = 1;
        // --- ĳ������ ���� �ݻ�����, ���� �ݻ����� ���ϱ�
        // �ʵ忡 �׷��� ��������Ʈ ������ ������
        SpriteRenderer sprRend = gameObject.GetComponentInChildren<SpriteRenderer>();
        // sprRend.bounds.size.x    // ��������Ʈ�� ���� ������
        // sprRend.bounds.size.y    // ��������Ʈ�� ���� ������
        HalfSize.x = sprRend.bounds.size.x / 2.0f - 0.23f;      // ĳ������ ���� �� ������
        HalfSize.y = sprRend.bounds.size.y / 2.0f - 0.05f;      // ĳ������ ���� �� ������
        HalfSize.z = 1.0f;
        // --- ĳ������ ���� �ݻ�����, ���� �ݻ����� ���ϱ�
        // (������ Ŀ�� ���� ����.)
    }
    private void Update()
    {
        if (CharacterHp > 0)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            if (h != 0.0f || v != 0.0f)
            {
                moveDir = new Vector3(h, v, 0.0f);
                if (1.0f < moveDir.magnitude)
                    moveDir.Normalize();

                transform.position += moveDir * moveSpeed * Time.deltaTime;
            }

            LismitMove();
        }
    }
    private void LismitMove()
    {
        m_CacCurPos = transform.position;

        if (m_CacCurPos.x < CamResol.m_VpWMin.x + HalfSize.x)            // CamResol.m_VpWMin : ȭ�� �ּ� ��ǥ
            m_CacCurPos.x = CamResol.m_VpWMin.x + HalfSize.x;            // CamResol.m_VpWMax : ȭ�� �ִ� ��ǥ
        if (CamResol.m_VpWMax.x - HalfSize.x < m_CacCurPos.x)
            m_CacCurPos.x = CamResol.m_VpWMax.x - HalfSize.x;

        if (m_CacCurPos.y < CamResol.m_VpWMin.y + HalfSize.y)
            m_CacCurPos.y = CamResol.m_VpWMin.y + HalfSize.y;
        if (CamResol.m_VpWMax.y - HalfSize.y < m_CacCurPos.y)
            m_CacCurPos.y = CamResol.m_VpWMax.y - HalfSize.y;

        transform.position = m_CacCurPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            CharacterHp -= 0.25f;
            CharacterHp_bar.fillAmount = CharacterHp;
        }
    }
}
