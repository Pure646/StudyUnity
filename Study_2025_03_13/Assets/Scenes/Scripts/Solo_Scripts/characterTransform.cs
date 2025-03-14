using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTransform : MonoBehaviour
{
    [SerializeField] private Vector2 MoveVec;
    [SerializeField] private float Speed;
    private void Update()
    {
        InputMove();
    }
    private void InputMove()
    {
        float moveX = InputSystem.Instance.MoveVec.x;
        float moveY = InputSystem.Instance.MoveVec.y;
        float mathfX = Mathf.Lerp(transform.position.x, transform.position.x + moveX, Time.deltaTime * Speed);
        float mathfY = Mathf.Lerp(transform.position.y, transform.position.y + moveY, Time.deltaTime * Speed);
        MoveVec = new Vector2(mathfX, mathfY);
        transform.position = MoveVec;

    }
}
