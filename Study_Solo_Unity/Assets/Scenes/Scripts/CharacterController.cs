using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private CharacterBase character;
    private NextScene loadscene;
    private void Awake()
    {
        character = GetComponent<CharacterBase>();
    }
    private void OnEnable()
    {
        InputSystem.Jump += Jumping;
        InputSystem.OnRun += Running;
        InputSystem.OffRun += Walking;
    }
    private void OnDisable()
    {
        InputSystem.Jump -= Jumping;
        InputSystem.OnRun -= Running;
        InputSystem.OffRun -= Walking;
    }
    private void Jumping()
    {
        character.Jump();
    }

    private void Running()
    {
        character.Run();
    }
    private void Walking()
    {
        character.Walk();
    }
}
