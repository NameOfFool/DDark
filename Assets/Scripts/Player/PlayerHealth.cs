using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private Animator _anim;
    [SerializeField] private Slider healthBar;
    private Rigidbody2D rb;
    public void Death()
    {

    }
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            currentHealth = currentHealth * value / maxHealth; maxHealth = value;
        }
    }
    private int currentHealth;
    public int CurrentHealth
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
                    healthBar.value = (float)currentHealth/maxHealth;
                }
            }
        }
    }



    public bool isInvincible { get; set; }
    public UnityEvent OnBegin { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public UnityEvent OnDone { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Awake()
    {
        currentHealth = MaxHealth;
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.value = (float)currentHealth/maxHealth;
    }
    public void Hurt(int damage, Vector2 knockback)
    {
        currentHealth -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    void Update()
    {

    }

    public IEnumerator ResetVelocity()
    {
        throw new System.NotImplementedException();
    }
}
