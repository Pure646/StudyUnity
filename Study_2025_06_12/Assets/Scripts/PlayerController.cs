using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;
    private float jumpForce = 680.0f;
    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;

    private float walkSpeed = 3.0f;
    private int m_ReserveJump;      // 점프 예약 변수

    private float hp = 3.0f;
    public Image[] hpImage;

    private GameObject m_OverlapBlock = null;
    // 보상이나 화살의 두세번 연속 충돌 방지용 변수

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            m_ReserveJump = 3;
        }

        // 점프한다.
        //if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        if((0 < m_ReserveJump) && 
            (-0.05f <= rigid2D.velocity.y && rigid2D.velocity.y <= 0.02f))
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            m_ReserveJump = 0;
        }
        if(0 < m_ReserveJump)
        {
            m_ReserveJump--;
        }
        // 좌우 이동
        int Key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) Key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) Key = -1;

        // 플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        //if(speedx < this.maxWalkSpeed)
        //{
        //    this.rigid2D.AddForce(transform.right * Key * this.walkForce);
        //}
        rigid2D.velocity = new Vector2((Key * walkSpeed), rigid2D.velocity.y);

        // 움직이는 방향에 따라 반전한다.
        if(Key != 0)
        {
            transform.localScale = new Vector3(Key, 1, 1);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 플레이어가 화면 밑으로 나갔다면 처음부터
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene("GameScene");
        }

        // --- 플레이어가 화면 좌우를 벗어나지 못하게 막기
        Vector3 pos = transform.position;
        if (pos.x < -2.5f) pos.x = -2.5f;
        if (pos.x > 2.5f) pos.x = 2.5f;
        transform.position = pos;
        // --- 플레이어가 화면 좌우를 벗어나지 못하게 막기
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("flag") == true)
        {
            //Debug.Log("골");
            SceneManager.LoadScene("ClearScene");
        }
        else if(coll.gameObject.name.Contains("WaterRoot") == true)
        {
            Die();
        }
        else if (coll.gameObject.name.Contains("arrowPrefab") == true)
        {
            if(m_OverlapBlock != coll.gameObject)
            {
                hp -= 1.0f;
                HPImgUpdate();
                if (hp <= 0.0f)  // 사망처리
                {
                    Die();
                }
                m_OverlapBlock = coll.gameObject;
            }
            Destroy(coll.gameObject);
        }
        else if(coll.gameObject.name.Contains("fish") == true)
        {
            if(m_OverlapBlock != coll.gameObject)
            {
                hp += 0.5f;         //에너지 증가
                if (3.0f < hp)
                    hp = 3.0f;
                HPImgUpdate();

                m_OverlapBlock = coll.gameObject;
            }
            Destroy(coll.gameObject);
        }
    }
    private void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    private void HPImgUpdate()
    {
        float a_CacHp = 0.0f;
        for (int i = 0; i < hpImage.Length; i++) 
        {
            a_CacHp = hp - (float)i;
            if (a_CacHp < 0.0f)
                a_CacHp = 0.0f;
            if (1.0f < a_CacHp)
                a_CacHp = 1.0f;
            if (0.45f < a_CacHp && a_CacHp < 0.55f)
                a_CacHp = 0.445f;

            hpImage[i].fillAmount = a_CacHp;
        }
    }
}
