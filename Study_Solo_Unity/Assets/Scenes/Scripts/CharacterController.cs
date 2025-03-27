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
        InputSystem.OnJump += Jumpping;
        InputSystem.OnRun += Running;
        InputSystem.OffRun += Walking;
    }
    private void OnDisable()
    {
        InputSystem.OnJump -= Jumpping;
        InputSystem.OnRun -= Running;
        InputSystem.OffRun -= Walking;
    }
    private void Jumpping()
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
