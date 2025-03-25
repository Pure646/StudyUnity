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

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);          // �� ��ȯ �ÿ��� ��ü�� ����
        }
    }
    private void Update()
    {
        Movemenet();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnRun?.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            OffRun?.Invoke();
        }
    }
    
    private void Movemenet()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        moveVec = new Vector2(InputX, InputY);
    }
}
