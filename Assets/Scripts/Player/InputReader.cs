using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input/Input Reader", fileName = "InputReader")]
public class InputReader : ScriptableObject, PlayerInputs.IMovementActions
{
    public event UnityAction<Vector2> MoveInput;
    public event UnityAction InventoryInput;
    public event UnityAction DashInput;
    public event UnityAction AttackInput;
    public event UnityAction InteractInput;

    public PlayerInputs Input;

    public void OnEnable()
    {
        if (Input == null)
        {
            Input = new PlayerInputs();
            Input.Movement.AddCallbacks(this);
        }
        Input.Enable();
    }
    private void OnDisable()
    {
        Input.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnMenuOpen(InputAction.CallbackContext context)
    {
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInventoryOPEN(InputAction.CallbackContext context)
    {
        InventoryInput?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
            DashInput?.Invoke();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(InteractInput !=null && context.started)
        {
            InteractInput.Invoke();
        }
    }
}
