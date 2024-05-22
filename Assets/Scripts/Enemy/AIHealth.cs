using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth = 10;
    private Animator _anim;
    private Rigidbody2D rb;
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
        CurrentHealth -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
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
    void Awake()
    {
        CurrentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
