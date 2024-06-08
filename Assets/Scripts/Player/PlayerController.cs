using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    public float MaxSpeed = 5f;
    public float DashDuration = 0.1f;
    public float DashCooldown = 3f;
    public float CurrentMoveSpeed { get { return MaxSpeed; } }
    [SerializeField]private InputReader inputReader;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    private Animator _anim;
    private bool _canMove = true;
    private GameObject _interactableObject;
    private const string _velocityX = "VelocityX";
    private const string _velocityY = "VelocityY";
    private const string _lastX = "LastX";
    private const string _lastY = "LastY";
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(_canMove)
            Move();
    }
     private void Move()
    {
        _rb.velocity = _moveInput * CurrentMoveSpeed;
        _anim.SetFloat(_velocityX, _rb.velocity.x);
        _anim.SetFloat(_velocityY, _rb.velocity.y);
        if (_rb.velocity != Vector2.zero)
        {
            _anim.SetFloat(_lastX, _rb.velocity.x);
            _anim.SetFloat(_lastY, _rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)//TODO Rework
    {
        if(other.TryGetComponent<Item>(out Item item))
        {
            _interactableObject = other.gameObject;
        }      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent<Item>(out Item item))
        {
            _interactableObject = null;
        }
    }
    private void Dash()
    {
        _rb.AddForce(_moveInput * 10f,ForceMode2D.Impulse);
    }
    #region Unuty Events
    private void OnEnable()
    {
        inputReader.MoveInput += OnMove;
        inputReader.DashInput += OnDash;
        inputReader.InteractInput +=OnInteract;
    }
    private void OnDisable()
    {
        inputReader.MoveInput -= OnMove;
        inputReader.DashInput -= OnDash;
        inputReader.InteractInput -=OnInteract;
    }
    private void OnMove(Vector2 moveInput)
    {
        _moveInput = moveInput;
    }
    private async void OnDash()
    {
        _canMove = false;
        Dash();
        inputReader.DashInput -= OnDash;
        await UniTask.WaitForSeconds(DashDuration);
        _canMove = true;
        await UniTask.WaitForSeconds(DashCooldown);
        inputReader.DashInput += OnDash;
    }
    private void OnInteract()
    {
        if(_interactableObject != null)
        {
            _interactableObject.GetComponent<Item>().Interact(gameObject);
        }
    }
    #endregion
}