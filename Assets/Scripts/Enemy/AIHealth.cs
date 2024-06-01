using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AIHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth = 10;
    private Animator _anim;
    private Rigidbody2D _rb;
    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            currentHealth = currentHealth * value / maxHealth; maxHealth = value;
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void Hurt(int damage, Vector2 knockback)
    {
        StopAllCoroutines();
        CurrentHealth -= damage;
        _rb.AddForce(knockback * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        StartCoroutine(ResetVelocity());
    }
    private int currentHealth;
    public bool isInvincible { get; set; }
    public int CurrentHealth
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

    public UnityEvent OnBegin {get;set;}
    public UnityEvent OnDone {get;set;}

    void Awake()
    {
        CurrentHealth = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public IEnumerator ResetVelocity()
    {
        yield return new WaitWhile(() =>isInvincible);
        _rb.velocity = Vector2.zero;
        OnDone?.Invoke();
    }
}
