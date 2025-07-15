using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;

    float moveSpeed = 10.0f; //�̵��ӵ�
    Vector3 moveDir = Vector3.zero; //�̵�����

    //--- ī�޶� ȸ���� ���� ����
    float rotSpeed = 350.0f;
    Vector3 m_CacVec = Vector3.zero;
    //--- ī�޶� ȸ���� ���� ����

    //--- ���̰� ã�� ���� ����
    public Terrain m_RefMap = null;
    //--- ���̰� ã�� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--- ī�޶� ȸ�� ���� �κ�
        if (Input.GetMouseButton(1) == true) //���콺 ������ ��ư ������ �ִ� ����
        {
            m_CacVec = transform.eulerAngles;

            m_CacVec.y += (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse X"));  // -1, 0, 1
            m_CacVec.x -= (rotSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse Y"));  // -1, 0, 1

            if (180.0f < m_CacVec.x && m_CacVec.x < 340.0f)
                m_CacVec.x = 340.0f;

            if (12.0f < m_CacVec.x && m_CacVec.x <= 180.0f)
                m_CacVec.x = 12.0f;

            transform.eulerAngles = m_CacVec;
        }
        //--- ī�޶� ȸ�� ���� �κ�

        //--- �̵� ���� �κ�
        h = Input.GetAxis("Horizontal");    //-1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");      //-1.0f ~ 1.0f

        //1�� ��� �����¿� �̵� ���� ���� ���
        moveDir = (Vector3.forward * v) + (Vector3.right * h);
        if (1.0f < moveDir.magnitude)
            moveDir.Normalize();

        transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);
        //1�� ��� �����¿� �̵� ���� ���� ��� default���� Space.Self
        //�ι�° �Ű������� ��������� ���� ��� Space.Self

        ////2�� ��� ���� ��ǥ�踦 �������� �������� �̵���Ű�� ���
        //moveDir = (transform.forward * v) + (transform.right * h);
        //if (1.0f < moveDir.magnitude)
        //    moveDir.Normalize();

        //transform.Translate(moveDir * Time.deltaTime * moveSpeed, Space.World);
        ////2�� ��� ���� ��ǥ�踦 �������� �������� �̵���Ű�� ���

        ////3�� ��� ���� ��ǥ�� �������� �̵���Ű�� ���
        //moveDir = (transform.forward * v) + (transform.right * h);
        //if (1.0f < moveDir.magnitude)
        //    moveDir.Normalize();

        //transform.position += moveDir * Time.deltaTime * moveSpeed;
        ////3�� ��� ���� ��ǥ�� �������� �̵���Ű�� ���
        //�ӵ� = �̵��Ÿ� / �ð� --> �ӵ� * �ð� = �̵��Ÿ� --> �ð� * �ӵ� = �̵��Ÿ�

        //--- ĳ���� ���̰� ����
        transform.position = new Vector3(transform.position.x,
                                m_RefMap.SampleHeight(transform.position) + 5.0f,
                                transform.position.z);
        //--- ĳ���� ���̰� ����

    }//void Update()

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Game_Mgr.Inst.DecreaseHp();     // ���ΰ� ��Ʈ �ϳ� ���� ��Ű��
            Destroy(coll.gameObject);
        }
    }

    public bool IsMove()
    {
        if(h == 0 && v == 0)
        {
            return false;           // ���� �ִٴ� �ǹ�
        }
        return true;                // �̵� ���̶�� �ǹ�
    }
}
