using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public bool MenuToggleInput{get; private set;}
    private PlayerInput _playerInput;
    private InputAction _menuAction;

    private InputManager()
    {

    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _playerInput = GetComponent<PlayerInput>();
        _menuAction = _playerInput.actions["MenuInteraction"];

    }
    private void Update()
    {
        MenuToggleInput = _menuAction.WasPressedThisFrame();
    }
}
