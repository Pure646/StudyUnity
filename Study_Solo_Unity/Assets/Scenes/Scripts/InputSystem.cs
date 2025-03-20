using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }

    public Vector2 MoveVec => moveVec;
    private Vector2 moveVec;

    private void Update()
    {
        
    }
    
    private void Movemenet()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        moveVec = new Vector2(InputX, InputY);
    }
}
