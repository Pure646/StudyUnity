using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum MonType
{
    MT_Zombi,
    MT_Missile,
    MT_Boss
}
public class Monster_Ctrl : MonoBehaviour
{
    public MonType m_MonType = MonType.MT_Zombi;

    // --- ���� ü�� ����
    private float m_MaxHp = 200.0f;
    private float m_CurHp = 200.0f;
    public Image m_HpBar;

    private float m_Speed = 4.0f;
    private Vector3 m_CurPos;

    // --- ���� �Լ��� �̿��� �̵� ������ ���� ����
    private Vector3 m_SpawnPos;         // ���� ��ġ
    private float m_CacPosY = 0.0f;     // ���� �Լ��� �� ���� ���� ���� ����
    private float m_RandY = 0.0f;       // ������ ������ ����� ����
    private float m_CycleSpeed = 0.0f;  // ������ ���� �ӵ� ����

    private void Start()
    {
        m_SpawnPos = transform.position;            // ������ ���� ��ġ ����
        m_RandY = Random.Range(0.5f, 2.0f);         // Sin �Լ��� ���� ����    // Sin ���̰�
        // Y ��
        m_CycleSpeed = Random.Range(1.8f, 5.0f);    // ������ ������          // ���� ���� ������ ���Ʒ� �����δ�.
        // X ��  // �������� X �� ����
    }
    private void Update()
    {
        if (m_MonType == MonType.MT_Zombi)
        {
            Zombi_AI_Update();
        }
        if (this.transform.position.x < CamResol.m_VpWMin.x - 2.0f)
        {
            Destroy(gameObject);
        }
    }
    private void Zombi_AI_Update()
    {
        m_CurPos = transform.position;
        m_CurPos.x += (-1.0f * m_Speed * Time.deltaTime);

        m_CacPosY += (Time.deltaTime * m_CycleSpeed);
        m_CurPos.y = m_SpawnPos.y + Mathf.Sin(m_CacPosY) * m_RandY;
        transform.position = m_CurPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AllyBullet")
        {
            TakeDamage(50.0f);
            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage(float a_Value)
    {
        if (m_CurHp <= 0.0f)        // �� ���Ͱ� �̹� �׾� ������...
            return;                 // �������� ������ �ʿ� ������ ���� ��Ű�ڴٴ� ��

        float a_CacDmg = a_Value;
        if (m_CurHp < a_Value)
            a_CacDmg = m_CurHp;
        Vector3 a_StCacPos = new Vector3(transform.position.x, transform.position.y + 1.14f, 0.0f);
        Game_Mgr.Inst.DamageText(-a_CacDmg, a_StCacPos, Color.red);

        m_CurHp -= a_Value;
        if (m_CurHp < 0.0f)
            m_CurHp = 0.0f;

        if (m_CurHp <= 0.0f)
            Destroy(gameObject);

        if(m_HpBar != null)
            m_HpBar.fillAmount = m_CurHp / m_MaxHp;
    }
}
