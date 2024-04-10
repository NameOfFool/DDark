using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    public float MaxSpeed = 5f;
    public float CurrentMoveSpeed{get{return MaxSpeed;}}
    private Vector2 moveInput;
    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new(moveInput.x * CurrentMoveSpeed, moveInput.y * CurrentMoveSpeed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
