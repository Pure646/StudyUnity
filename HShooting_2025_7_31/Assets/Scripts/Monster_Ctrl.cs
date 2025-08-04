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

    //---- 몬스터 체력 변수
    float m_MaxHp = 200.0f;
    float m_CurHp = 200.0f;
    public Image m_HpBar = null;
    //---- 몬스터 체력 변수

    float m_Speed = 4.0f;       //이동속도
    Vector3 m_CurPos;           //위치 계산용 변수

    //--- 싸인 함수를 이용한 이동 패턴을 위한 변수
    Vector3 m_SpawnPos;         //스폰 위치
    float m_CacPosY = 0.0f;     //싸인 함수에 들어갈 누적 각도 계산용 변수
    float m_RandY = 0.0f;       //랜덤한 진폭값 저장용 변수
    float m_CycleSpeed = 0.0f;  //랜덤한 진동 속도 변수
    //--- 싸인 함수를 이용한 이동 패턴을 위한 변수

    //--- 총알 발사 관련 변수 선언
    public GameObject m_ShootPos = null;
    public GameObject m_BulletPrefab = null;
    float shoot_Time = 0.0f;        //총알 발사 주기 계산용 변수
    float shoot_Delay = 1.5f;       //총알 쿨 타임
    float BulletMySpeed = 10.0f;    //총알 이동 속도
    //--- 총알 발사 관련 변수 선언

    //--- 미사일 행동 패턴
    Hero_Ctrl m_RefHero = null;     //몬스터가 추적하게 될 주인공 객체 변수
    Vector3   m_DirVec;
    //--- 미사일 행동 패턴

    // Start is called before the first frame update
    void Start()
    {
        m_RefHero = GameObject.FindObjectOfType<Hero_Ctrl>();

        m_SpawnPos = transform.position;    //몬스터의 스폰 위치 저장
        m_RandY = Random.Range(0.5f, 2.0f);         //Sin 함수의 랜덤 진폭
        m_CycleSpeed = Random.Range(1.8f, 5.0f);    //진동수 랜덤값
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MonType == MonType.MT_Zombi)
            Zombi_AI_Update();
        else if (m_MonType == MonType.MT_Missile)
            Missile_AI_Update();

        if (this.transform.position.x < CamResol.m_VpWMin.x - 2.0f)
            Destroy(gameObject);    //왼쪽 화면을 벗어나면 즉시 제거
    }

    void Zombi_AI_Update()
    {
        m_CurPos = transform.position;
        m_CurPos.x += (-1.0f * m_Speed * Time.deltaTime);

        m_CacPosY += (Time.deltaTime * m_CycleSpeed);
        m_CurPos.y = m_SpawnPos.y + Mathf.Sin(m_CacPosY) * m_RandY;

        transform.position = m_CurPos;

        //--- 총알 발사
        if (m_BulletPrefab == null)
            return;

        shoot_Time += Time.deltaTime;
        if (shoot_Delay <= shoot_Time)
        {
            shoot_Time = 0.0f;

            GameObject a_NewObj = Instantiate(m_BulletPrefab);
            Bullet_Ctrl a_BulletSc = a_NewObj.GetComponent<Bullet_Ctrl>();
            a_BulletSc.BulletSpawn(m_ShootPos.transform.position, Vector2.left, BulletMySpeed);
        }
        //--- 총알 발사

    }//void Zombi_AI_Update()

    void Missile_AI_Update()
    {
        m_CurPos = transform.position;
        m_DirVec = Vector3.left;

        if (m_RefHero != null)
        {
            Vector3 a_CacVec = m_RefHero.transform.position - transform.position;
            m_DirVec = a_CacVec;

            //미사일이 주인공과의 거리가 우측방향으로 3.5m 이상이면 높낮이 변화없이
            //좌측으로만 이동시키려는 의도
            if (a_CacVec.x < -3.5f)
                m_DirVec.y = 0.0f;
        }

        m_DirVec.Normalize();
        m_DirVec.x = -1.0f;  //주인공을 지나치고 난 후에는 무조건 왼쪽 방향으로 이동하게...
        m_DirVec.z = 0.0f;

        m_CurPos += (m_DirVec * Time.deltaTime * m_Speed);
        transform.position = m_CurPos;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "AllyBullet")
        {
            TakeDamage(60.0f);
            Destroy(coll.gameObject);
        }
    }//void OnTriggerEnter2D(Collider2D coll)

    public void TakeDamage(float a_Value)
    {
        if (m_CurHp <= 0.0f) //이 몬스터가 이미 죽어 있으면...
            return;          //데미지를 차감할 필요 없으니 리턴 시키겠다는 뜻

        float a_CacDmg = a_Value;
        if (m_CurHp < a_Value)
            a_CacDmg = m_CurHp;

        Vector3 a_StCacPos = new Vector3(transform.position.x, transform.position.y + 1.14f, 0.0f);
        Game_Mgr.Inst.DamageText(-a_CacDmg, a_StCacPos, Color.red);

        m_CurHp -= a_Value;
        if (m_CurHp < 0.0f)
            m_CurHp = 0.0f;

        if (m_HpBar != null)
            m_HpBar.fillAmount = m_CurHp / m_MaxHp;

        if (m_CurHp <= 0.0f)
        {
            //--- 골드 보상 (임시 코드)
            Game_Mgr.Inst.SpawnCoin(transform.position);
            //--- 골드 보상 (임시 코드)

            Destroy(gameObject);
        }
    }//public void TakeDamage(float a_Value)

}//public class Monster_Ctrl : MonoBehaviour
