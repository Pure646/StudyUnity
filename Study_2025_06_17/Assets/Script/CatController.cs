using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class CatController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D Rigd;
    private float MaxSpeed = 10f;
    private float CatSpeed = 3f;

    private void Start()
    {
        Rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if(Rigd.velocity.x * 1f > 0f)
            {

            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if(Rigd.velocity.x * -1f > 0f)
            {

            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            if(CatSpeed > Rigd.velocity.x * -1f)
            {
                Rigd.AddForce(Vector2.left * MaxSpeed);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            if(CatSpeed > Rigd.velocity.x * 1f)
            {
                Rigd.AddForce(Vector2.right * MaxSpeed);
            }
        }
        //if(transform.position.magnitude > 0.001)
        //{
        //    animator.speed = Speed / 2.0f;
        //}
        //else if(transform.position.magnitude < 0.001)
        //{
        //    animator.speed = 0;
        //}
    }

}
