using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour
{
    //몬스터의 상태 정보
    public enum MonsterState { idle, trace, attack, die };

    //몬스터의 현재 상태 정보를 저장할 Enum 변수
    public MonsterState monsterState = MonsterState.idle;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    

    // 추적 사정거리
    public float traceDist = 10.0f;
    // 공격 사정거리
    public float attackDist = 1.7f;
    // 죽음 처리
    private bool isDie = false;

    // 혈흔 효과 프리팹
    public GameObject bloodEffect;

    // 혈흔 데칼 효과 프리팹
    public GameObject bloodDecal;
    void Start()
    {
        //몬스터의 Transform 할당
        monsterTr = this.gameObject.GetComponent<Transform>();
        //추적 대상인 Player의 Transform 할당
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //NavmeshAgent 컴포넌트 할당
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        // Animator 컴포넌트
        animator = this.gameObject.GetComponent<Animator>();
        
        // 추적 대상의 위치를 설정하면 바로 추적 시작
        //nvAgent.destination = playerTr.position;

        // 일정한 간격으로 몬스터의 행동 상태를 체크하는 코루틴 함수 실행
        StartCoroutine(this.CheckMonsterState());

        // 몬스터의 상태에 따라 동작하는 루틴을 실행하는 코루틴 함수 실행
        StartCoroutine(this.MonsterAction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if(dist <= attackDist)      // 공격거리 범위 이내로 들어왔는지 확인
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)     // 추적거리 범위 이내로 들어왔는지 확인
            {
                monsterState = MonsterState.trace;      // 몬스터의 상태를 추적으로 설정
            }
            else
            {
                monsterState = MonsterState.idle;       
            }
        }
    }
    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch(monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsTrace", true);
                    animator.SetBool("IsAttack", false);
                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);

                    float a_RotSpeed = 6.0f;
                    Vector3 a_CacDir = playerTr.position - transform.position;
                    a_CacDir.y = 0.0f;
                    if (0.0f < a_CacDir.magnitude)
                    {
                        Quaternion a_TargetRot = Quaternion.LookRotation(a_CacDir.normalized);
                        transform.rotation = Quaternion.Slerp(transform.rotation, a_TargetRot, Time.deltaTime * a_RotSpeed);
                    }
                    break;
            }
            yield return null;      //<-- 한 플레임이 도는 동안 잠시 대기
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BULLET")
        {
            CreateBloodEffect(collision.transform.position);

            Destroy(collision.gameObject);

            animator.SetTrigger("IsHit");
        }
    }

    private void CreateBloodEffect(Vector3 pos)
    {
        GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos, Quaternion.identity);
        blood1.GetComponent<ParticleSystem>().Play();
        Destroy(blood1, 3.0f);

        // 데칼 생성 위치
        Vector3 decalPos = monsterTr.position + (Vector3.up * 0.05f);
        // 데칼의 회전값을 무작위로 설정
        Quaternion decalRot = Quaternion.Euler(90, 0, Random.Range(0, 360));

        // 데칼 프리팹 생성
        GameObject blood2 = (GameObject)Instantiate(bloodDecal, decalPos, decalRot);
        // 데칼의 크기도 불규칙적으로 나타나게끔 스케일 조정
        float scale = Random.Range(1.5f, 3.5f);
        blood2.transform.localScale = Vector3.one * scale;

        Destroy(blood2, 5.0f);
    }
}
