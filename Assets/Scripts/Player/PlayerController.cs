using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    public float MaxSpeed = 5f;
    public float CurrentMoveSpeed{get{return MaxSpeed;}}
    private bool _isFacingRight = true;
    public bool isFacingRight
    {
        get => _isFacingRight;
        set
        {
            if(_isFacingRight != value)
                transform.localScale *=new Vector2(-1,1);
                _isFacingRight = value;
        }
    }
    private Vector2 moveInput;
    private Rigidbody2D _rb;
    private Animator _anim;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new(moveInput.x * CurrentMoveSpeed, moveInput.y * CurrentMoveSpeed);
        Flip();
    }
    private void Flip()
    {
        if(moveInput.x >0 && !isFacingRight)
            isFacingRight = true;
        else if(moveInput.x < 0 && isFacingRight)
            isFacingRight = false;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
            _anim.SetTrigger("Attack");
    }
}
