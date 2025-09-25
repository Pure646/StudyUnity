using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}
public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    public float moveSpeed = 10.0f;

    public float rotSpeed = 100.0f;
    // �ν����ͺ信 ǥ���� �ִϸ��̼� Ŭ���� ����
    public Anim anim;
    // �Ʒ��� �ִ� 3D ���� Animation ������Ʈ�� �����ϱ� ���� ����
    public Animation _animation;

    //Player�� ���� ����
    public int hp = 100;

    // Player�� ���� �ʱ갪
    public int initHp;
    // Player�� Health bar �̹���
    public Image imgHpbar;

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        _animation = GetComponentInChildren<Animation>();

        // Animation ������Ʈ�� �ִϸ��̼� Ŭ���� �����ϰ� ����
        _animation.clip = anim.idle;
        _animation.Play();

        // ���� �ʱ갪 ����
        initHp = hp;
    }
    private void Update()
    {
        if (GameMgr.s_GameState == GameState.GameEnd)
            return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // �����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        if (1.0f < moveDir.magnitude)       // �밢�� �ӵ� 1�� ����
            moveDir.Normalize();

        // Translate(�̵����� * �ӵ� * ������ * Time.deltaTime, ������ǥ);
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);

        if(Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
        {
            float addRotSpeed = 3.0f;
            // Vector3.up ���� �������� rotSpeed ��ŭ�� �ӵ��� ȸ��
            transform.Rotate(Vector3.up * addRotSpeed * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        }

        // Ű���� �Է°��� �������� ������ �ִϸ��̼� ����
        if(v >= 0.01f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
        }
        else if(v <= -0.01f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.3f);
        }
        else if(h >= 0.01f)
        {
            _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else if(h <= -0.01f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hp <= 0.0f)
        {
            return;
        }
        hp -= 10;

        imgHpbar.fillAmount = (float)hp / (float)initHp;

        //Debug.Log("Player Hp = " + hp.ToString());

        if (hp <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Debug.Log("Player Die!!");

        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");

        foreach (GameObject monster in monsters)
        {
            // ���������� ������� �� �Ⱦ��� �Ѵ�. & ��� �Լ��� ã���� ���� �޸𸮰� ���� ���ȴ�.
            // ������ ȣ�� ������ ����.
            monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
            //monster.GetComponent<MonsterCtrl>().OnPlayerDie();
        }

        _animation.Stop();      // �ִϸ��̼� ������Ʈ�� �ִϸ��̼� ���� �Լ�
        GameMgr.s_GameState = GameState.GameEnd;
        
    }
}
