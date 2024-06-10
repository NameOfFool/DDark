using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable, IMoveable, ITriggerCheckable
{
    #region Damageable props
    [SerializeField] private float maxHealth = 10;
    private Animator _anim;
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            currentHealth = currentHealth * value / maxHealth; maxHealth = value;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void Hurt(float damage, Vector2 knockback)
    {
        StopAllCoroutines();
        CurrentHealth -= damage;
        RB.AddForce(knockback * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        StartCoroutine(ResetVelocity());
    }
    private float currentHealth;
    public bool isInvincible { get; set; }
    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (!isInvincible)
                if (value <= MaxHealth)
                {
                    if (value < currentHealth)
                    {
                        _anim.SetTrigger("Hurt");
                    }
                    if (value > 0)
                        currentHealth = value;
                    else
                        currentHealth = 0;
                }
        }
    }
    #endregion
    #region Idle vars
    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;
    #endregion
    #region States
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

    public EnemyAttackState AttackState { get; set; }

    #endregion

    public UnityEvent OnBegin { get; set; }
    public UnityEvent OnDone { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool isFacingRight { get; set; }
    public bool isChasing { get; set; }
    public bool canAttack { get; set; }

    private void Awake()
    {
        CurrentHealth = maxHealth;
        RB = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicalUpdate();
    }

    public IEnumerator ResetVelocity()
    {
        yield return new WaitWhile(() => isInvincible);
        RB.velocity = Vector2.zero;
        OnDone?.Invoke();
    }


    public void Move(Vector2 velocity)
    {
        RB.velocity = velocity;
    }

    public void CheckFacingSide(Vector2 velocity)
    {

    }
    #region Animation Triggers
    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayerFootstepSound
    }
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentState.AnimationTriggerEvent(triggerType);
    }

    public void SetChaseStatus(bool status)
    {
        isChasing = status;
    }

    public void SetAttackStatus(bool status)
    {
        canAttack = status;
    }
    #endregion
}
