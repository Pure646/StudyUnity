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
    // --- 키보드 입력값 변수 선언.

    // 주인공 화면 밖으로 나갈 수 없도록 막기 위한 변수
    private Vector3 HalfSize = Vector3.zero;
    private Vector3 m_CacCurPos = Vector3.zero;

    [SerializeField] private Image CharacterHp_bar;
    public static float CharacterHp = 1;

    private void Start()
    {
        CharacterHp = 1;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            CharacterHp -= 0.25f;
            CharacterHp_bar.fillAmount = CharacterHp;
        }
    }
}
