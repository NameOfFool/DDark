using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public static PlayerInput PlayerInput;

    public bool AttackInput { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public bool MenuOpenInput{get;private set;}

    private InputAction _attackAction;
    private InputAction _moveAction;
    private InputAction _menuOpenAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        PlayerInput = GetComponent<PlayerInput>();
        _attackAction = PlayerInput.actions["Attack"];
        _moveAction = PlayerInput.actions["Move"];
    }
    private void Update()
    {
    }
}
