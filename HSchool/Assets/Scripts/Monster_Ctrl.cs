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

    // --- 몬스터 체력 변수
    private float m_MaxHp = 200.0f;
    private float m_CurHp = 200.0f;
    public Image m_HpBar;

    private float m_Speed = 4.0f;
    private Vector3 m_CurPos;

    // --- 싸인 함수를 이용한 이동 패턴을 위한 변수
    private Vector3 m_SpawnPos;         // 스폰 위치
    private float m_CacPosY = 0.0f;     // 싸인 함수에 들어갈 누적 각도 계산용 변수
    private float m_RandY = 0.0f;       // 랜덤한 진폭값 저장용 변수
    private float m_CycleSpeed = 0.0f;  // 랜덤한 진동 속도 변수

    private void Start()
    {
        m_SpawnPos = transform.position;            // 몬스터의 스폰 위치 저장
        m_RandY = Random.Range(0.5f, 2.0f);         // Sin 함수의 랜덤 진폭    // Sin 높이값
        // Y 축
        m_CycleSpeed = Random.Range(1.8f, 5.0f);    // 진동수 랜덤값          // 높을 수록 빠르게 위아래 움직인다.
        // X 축  // 높을수록 X 축 감소
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
}
