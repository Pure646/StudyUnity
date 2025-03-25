using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 characterMoveVec;
    public float characterSpeed;
    public float characterJumpPower;

    private float saveX;           
    private float saveY;
    private bool OnSave;
    private bool OnGround;
    private bool OnRun;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 1;
    }
    private void FixedUpdate()
    {
        characterMovement();
    }
    private void LateUpdate()
    {
        SaveTransformPoint();
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
        characterMoveVec = new Vector2(InputSystem.Instance.MoveVec.x * characterSpeed, characterMoveVec.y);

        rigid.AddForce(characterMoveVec, ForceMode2D.Impulse);
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
