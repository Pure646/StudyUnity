using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 characterMoveVec;
    private Animator animator;

    public float characterSpeed;

    public float characterJumpPower;
    private float current_Add_Verocity;
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
        characterJumpPower = 1f;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.gravityScale = 1;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rigid.gravityScale = 3;
    }
    public void Jump()
    {
        characterMoveVec.y += characterJumpPower;
        current_Add_Verocity = characterMoveVec.y + characterJumpPower;
        if(OnGround)
        {
            characterMoveVec.y = 0;
        }
        else
        {
            air = Mathf.Lerp(air, current_Add_Verocity, Time.deltaTime * 2);
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
