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

    // ���� �����Ÿ�
    public float traceDist = 10.0f;
    // ���� �����Ÿ�
    public float attackDist = 1.7f;
    // ���� ó��
    private bool isDie = false;
    void Start()
    {
        //������ Transform �Ҵ�
        monsterTr = this.gameObject.GetComponent<Transform>();
        //���� ����� Player�� Transform �Ҵ�
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //NavmeshAgent ������Ʈ �Ҵ�
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

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
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    break;
                case MonsterState.attack:
                    break;
            }
            yield return null;      //<-- �� �÷����� ���� ���� ��� ���
        }
    }
}
