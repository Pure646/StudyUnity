using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero_Ctrl : MonoBehaviour
{
    // --- 주인공 체력 변수
    float m_MaxHp = 200.0f;
    [HideInInspector] public float m_CurHp = 200.0f;
    public Image m_HpBar = null;

    // --- 키보드 입력값 변수 선언.
    private float h = 0.0f;
    private float v = 0.0f;
    private float moveSpeed = 7.0f;
    private Vector3 moveDir = Vector3.zero;

    // --- 주인공 화면 밖으로 나갈 수 없도록 막기 위한 변수
    private Vector3 HalfSize = Vector3.zero;
    private Vector3 m_CacCurPos = Vector3.zero;

    // --- 총알 발사 변수
    public GameObject m_BulletPrefab = null;
    public GameObject m_ShootPos = null;
    private float m_ShootCool = 0.0f;           // 총알 발사 주기 계산용 변수

    private void Start()
    {
        // --- 캐릭터의 가로 반사이즈, 세로 반사이즈 구하기
        // 필드에 그려진 스프라이트 사이즈 얻어오기
        SpriteRenderer sprRend = gameObject.GetComponentInChildren<SpriteRenderer>();
        // sprRend.bounds.size.x    // 스프라이트의 가로 사이즈
        // sprRend.bounds.size.y    // 스프라이트의 세로 사이즈
        HalfSize.x = sprRend.bounds.size.x / 2.0f - 0.23f;      // 캐릭터의 가로 반 사이즈
        HalfSize.y = sprRend.bounds.size.y / 2.0f - 0.05f;      // 캐릭터의 세로 반 사이즈
        HalfSize.z = 1.0f;
        // --- 캐릭터의 가로 반사이즈, 세로 반사이즈 구하기
        // (여백이 커서 조금 줄임.)
    }
    private void Update()
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

        FireUpdate();
    }
    private void LismitMove()
    {
        m_CacCurPos = transform.position;

        if (m_CacCurPos.x < CamResol.m_VpWMin.x + HalfSize.x)            // CamResol.m_VpWMin : 화면 최소 좌표
            m_CacCurPos.x = CamResol.m_VpWMin.x + HalfSize.x;            // CamResol.m_VpWMax : 화면 최대 좌표
        if (CamResol.m_VpWMax.x - HalfSize.x < m_CacCurPos.x)
            m_CacCurPos.x = CamResol.m_VpWMax.x - HalfSize.x;

        if (m_CacCurPos.y < CamResol.m_VpWMin.y + HalfSize.y)
            m_CacCurPos.y = CamResol.m_VpWMin.y + HalfSize.y;
        if (CamResol.m_VpWMax.y - HalfSize.y < m_CacCurPos.y)
            m_CacCurPos.y = CamResol.m_VpWMax.y - HalfSize.y;

        transform.position = m_CacCurPos;
    }
    private void FireUpdate()
    {
        if (0.0f < m_ShootCool)
            m_ShootCool -= Time.deltaTime;
        if(m_ShootCool <= 0.0f)     // 주기적으로 자동 발사
        {
            m_ShootCool = 0.15f;

            GameObject a_CloneObj = Instantiate(m_BulletPrefab);
            a_CloneObj.transform.position = m_ShootPos.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Monster")
        {
            Monster_Ctrl a_RefMon = coll.gameObject.GetComponent<Monster_Ctrl>();
            if (a_RefMon != null)
                a_RefMon.TakeDamage(1000);

            TakeDamage(50.0f);
        }
    }
    private void TakeDamage(float a_Value)
    {
        if (m_CurHp <= 0.0f)
            return;

        Vector3 a_StCacPos = new Vector3(transform.position.x, transform.position.y + 1.14f, 0.0f);
        Game_Mgr.Inst.DamageText(-a_Value, a_StCacPos, Color.blue);

        m_CurHp -= a_Value;
        if (m_CurHp < 0.0f)
            m_CurHp = 0.0f;

        if (m_HpBar != null)
            m_HpBar.fillAmount = m_CurHp / m_MaxHp;

        if(m_CurHp <= 0.0f)     // 사망처리
        {
            Time.timeScale = 0.0f;      // 일시정지
        }
    }
}
