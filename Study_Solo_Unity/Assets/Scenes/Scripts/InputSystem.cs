using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }

    public Vector2 MoveVec => moveVec;
    private Vector2 moveVec;

    public static event Action OnJump;
    public static event Action OnRun;
    public static event Action OffRun;
    public static event Action Switch_Scene;
    public static event Action Current_Scene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);          // 씬 전환 시에도 객체를 유지
        }
    }

    private void Update()
    {
        Movemenet();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnRun?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OffRun?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Switch_Scene?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Current_Scene?.Invoke();
        }
    }
    
    private void Movemenet()
    {
        float InputX = Input.GetAxis("Horizontal");

        moveVec = Vector2.right * InputX;
    }
}
