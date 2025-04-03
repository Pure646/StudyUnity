using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 characterMoveVec;
    private Animator animator;

    private int More_Jump;
    public int Add_Jump = 1;

    public float characterJumpPower;
    public float characterSpeed;
    private float air;

    private float saveX;           
    private float saveY;
    private bool OnSave;
    private bool OnGround;
    private bool OnRun;
    
    private void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        rigid.gravityScale = 1;
        characterJumpPower = 10f;
        More_Jump = Add_Jump;
    }
    private void Update()
    {
        Character_Animator();
    }
    private void FixedUpdate()
    {
        characterMovement();
    }
    private void LateUpdate()
    {
        SaveTransformPoint();
        Character_Rotation();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Coin"))
        {
            // UI 에서 coin의 돈이 올라간다.
            // coin의 Object가 사라진다.
            // Object 사라지는 Effect를 구현시킨다.

            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
            More_Jump = Add_Jump;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
    public void Jump()
    {
        if(More_Jump > 0)
        {
            More_Jump--;
            rigid.velocity = new Vector2(rigid.velocity.x, characterJumpPower);
        }
    }
    public void Run()
    {
        OnRun = true;
    }
    public void Walk()
    {
        OnRun = false;
    }
    private void characterMovement()
    {
        if(OnRun)
        {
            characterSpeed = 1f;
        }
        else
        {
            characterSpeed = 0.5f;
        }
        characterMoveVec = new Vector2(InputSystem.Instance.MoveVec.x * characterSpeed, characterMoveVec.y * Time.deltaTime);

        rigid.AddForce(characterMoveVec, ForceMode2D.Impulse);

    }
    private void Character_Rotation()
    {
        if(InputSystem.Instance.MoveVec.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if(InputSystem.Instance.MoveVec.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void Character_Animator()
    {
        animator.SetFloat("Magnitude", characterMoveVec.magnitude);
    }
    private void SaveTransformPoint()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            saveX = transform.position.x;
            saveY = transform.position.y;
            OnSave = true;
        }
        
        if (transform.position.y < -50f || Input.GetKeyDown(KeyCode.L))
        {
            if(OnSave)
            {
                transform.position = new Vector2(saveX, saveY);
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else
            {
                transform.position = Vector2.zero;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                Debug.Log("저장된 세이브 Position이 없습니다.");
            }
        }
    }
}
