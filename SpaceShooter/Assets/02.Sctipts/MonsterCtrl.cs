using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour
{
    //������ ���� ����
    public enum MonsterState { idle, trace, attack, die };

    //������ ���� ���� ������ ������ Enum ����
    public MonsterState monsterState = MonsterState.idle;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    

    // ���� �����Ÿ�
    public float traceDist = 10.0f;
    // ���� �����Ÿ�
    public float attackDist = 1.7f;
    // ���� ó��
    private bool isDie = false;

    // ���� ȿ�� ������
    public GameObject bloodEffect;

    // ���� ��Į ȿ�� ������
    public GameObject bloodDecal;
    void Start()
    {
        //������ Transform �Ҵ�
        monsterTr = this.gameObject.GetComponent<Transform>();
        //���� ����� Player�� Transform �Ҵ�
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //NavmeshAgent ������Ʈ �Ҵ�
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        // Animator ������Ʈ
        animator = this.gameObject.GetComponent<Animator>();
        
        // ���� ����� ��ġ�� �����ϸ� �ٷ� ���� ����
        //nvAgent.destination = playerTr.position;

        // ������ �������� ������ �ൿ ���¸� üũ�ϴ� �ڷ�ƾ �Լ� ����
        StartCoroutine(this.CheckMonsterState());

        // ������ ���¿� ���� �����ϴ� ��ƾ�� �����ϴ� �ڷ�ƾ �Լ� ����
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

            if(dist <= attackDist)      // ���ݰŸ� ���� �̳��� ���Դ��� Ȯ��
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)     // �����Ÿ� ���� �̳��� ���Դ��� Ȯ��
            {
                monsterState = MonsterState.trace;      // ������ ���¸� �������� ����
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
            yield return null;      //<-- �� �÷����� ���� ���� ��� ���
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

        // ��Į ���� ��ġ
        Vector3 decalPos = monsterTr.position + (Vector3.up * 0.05f);
        // ��Į�� ȸ������ �������� ����
        Quaternion decalRot = Quaternion.Euler(90, 0, Random.Range(0, 360));

        // ��Į ������ ����
        GameObject blood2 = (GameObject)Instantiate(bloodDecal, decalPos, decalRot);
        // ��Į�� ũ�⵵ �ұ�Ģ������ ��Ÿ���Բ� ������ ����
        float scale = Random.Range(1.5f, 3.5f);
        blood2.transform.localScale = Vector3.one * scale;

        Destroy(blood2, 5.0f);
    }
}
