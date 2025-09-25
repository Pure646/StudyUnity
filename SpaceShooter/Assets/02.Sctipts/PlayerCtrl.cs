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
    // 인스펙터뷰에 표시할 애니메이션 클래스 변수
    public Anim anim;
    // 아래에 있는 3D 모델의 Animation 컴포넌트에 접근하기 위한 변수
    public Animation _animation;

    //Player의 생명 변수
    public int hp = 100;

    // Player의 생명 초깃값
    public int initHp;
    // Player의 Health bar 이미지
    public Image imgHpbar;

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        _animation = GetComponentInChildren<Animation>();

        // Animation 컴포넌트의 애니메이션 클립을 지정하고 실행
        _animation.clip = anim.idle;
        _animation.Play();

        // 생명 초깃값 설정
        initHp = hp;
    }
    private void Update()
    {
        if (GameMgr.s_GameState == GameState.GameEnd)
            return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        if (1.0f < moveDir.magnitude)       // 대각선 속도 1로 고정
            moveDir.Normalize();

        // Translate(이동방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표);
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);

        if(Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
        {
            float addRotSpeed = 3.0f;
            // Vector3.up 축을 기준으로 rotSpeed 만큼의 속도로 회전
            transform.Rotate(Vector3.up * addRotSpeed * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        }

        // 키보드 입력값을 기준으로 동작할 애니메이션 수행
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
            // 유지보수가 어려워서 잘 안쓰긴 한다. & 모든 함수를 찾느라 많이 메모리가 많이 사용된다.
            // 있으면 호출 없으면 말고.
            monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
            //monster.GetComponent<MonsterCtrl>().OnPlayerDie();
        }

        _animation.Stop();      // 애니메이션 컴포넌트의 애니메이션 중지 함수
        GameMgr.s_GameState = GameState.GameEnd;
        
    }
}
