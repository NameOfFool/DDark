using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private Animator _anim;
    private Rigidbody2D rb;
    public void Die()
    {

    }
    [SerializeField] private float maxHealth = 100;
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            currentHealth = currentHealth * value / maxHealth; maxHealth = value;
        }
    }
    private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value <= MaxHealth)
            {
                if (value < currentHealth)
                {
                    _anim.SetTrigger("Hurt");
                }
                if (value >= 0)
                {
                    currentHealth = value;
                }
            }
        }
    }



    public bool isInvincible { get; set; }
    public UnityEvent OnBegin { get; set;}
    public UnityEvent OnDone { get; set;}
    public event UnityAction OnPlayerDamaged;
    public float GetHealthPercent()
    {
        return CurrentHealth / MaxHealth * 100;
    }
    void Awake()
    {
        currentHealth = MaxHealth;
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Hurt(float damage)
    {
        currentHealth -= damage;
        OnPlayerDamaged.Invoke();
    }
    public void Hurt(float damage, Vector2 knockback)
    {
        currentHealth -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
        OnPlayerDamaged?.Invoke();
    }

    void Update()
    {

    }

    public IEnumerator ResetVelocity()
    {
        yield return new WaitWhile(() => isInvincible);
        OnDone?.Invoke();
    }
}
