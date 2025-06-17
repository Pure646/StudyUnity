using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;
    private float jumpForce = 680.0f;
    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // 점프한다.
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우 이동
        int Key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) Key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) Key = -1;

        // 플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * Key * this.walkForce);
        }

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
        if (pos.x < -2.0f) pos.x = -2.0f;
        if (pos.x > 2.0f) pos.x = 2.0f;
        transform.position = pos;
        // --- 플레이어가 화면 좌우를 벗어나지 못하게 막기
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("flag") == true)
        {
            //Debug.Log("골");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
