using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CatController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D Rigd;
    private CapsuleCollider2D CapsuleColider;
    private PointArrow pointer;
    [SerializeField] private float MaxSpeed = 3.5f;
    private bool OnGround;
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        Rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CapsuleColider = GetComponent<CapsuleCollider2D>();
        pointer = GameObject.FindObjectOfType<PointArrow>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.eulerAngles.y == 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(transform.eulerAngles.y == 180f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            if(Rigd.velocity.x > MaxSpeed * -1f)
            {
                Rigd.AddForce(Vector2.left, ForceMode2D.Impulse);       //ForceMode2D.Impulse : 순간적인 힘을 줘서 방향을 바꿈.
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            if(Rigd.velocity.x < MaxSpeed * 1f)
            {
                Rigd.AddForce(Vector2.right, ForceMode2D.Impulse);
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(Mathf.Abs(Rigd.velocity.x) >= 0f)
            {
                Rigd.velocity = new Vector2(0, Rigd.velocity.y);
            }
        }
        if(OnGround)
        {   // 지상에 있을 때
            if (Mathf.Abs(Rigd.velocity.x) > 0)
            {   // 방향에 상관 없이 움직이고 있을 때
                animator.speed = Mathf.Abs(Rigd.velocity.x) / 2.0f;
            }
            else
            {   // 멈춰 있을 때
                animator.speed = 0f;
            }
        }
        else
        {   // 공중에 있을 때
            animator.speed = 0.5f;
        }

        if (transform.position.x > 3.5f)
        {   // 왼쪽 최대치
            transform.position = new Vector2(3.5f, transform.position.y);
        }
        else if (transform.position.x < -3.5f)
        {   // 오른쪽 최대치
            transform.position = new Vector2(-3.5f, transform.position.y);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {   // OnGround 상태에서 점프키를 눌렀을 때
            Rigd.AddForce(Vector2.up * 350f);
        }
        if (PointArrow.HealthPoint < 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    //public LayerMask layerMask;
    //private void GroundRay()
    //{
    //    if (Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask))
    //    {
    //        OnGround = true;
    //        animator.SetBool("OnGround", OnGround);
    //    }
    //    else
    //    {
    //        OnGround = false;
    //        animator.SetBool("OnGround", OnGround);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Rigd.velocity.y <= 0f)
        {
            OnGround = true;
            animator.SetBool("OnGround", OnGround);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Rigd.velocity.y > 0f)
        {
            OnGround = false;
            animator.SetBool("OnGround", OnGround);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fish(Clone)")
        {
            PointArrow.HealthPoint++;
            PointArrow.Hit = true;
            Destroy(collision.gameObject);
        }
        if (collision.name == "arrow(Clone)")
        {
            PointArrow.HealthPoint--;
            PointArrow.Hit = true;
            Destroy(collision.gameObject);
        }
    }
}
