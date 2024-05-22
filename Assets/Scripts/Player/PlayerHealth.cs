using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private Animator _anim;
    private Rigidbody2D rb;
    public void Death()
    {

    }
    [SerializeField] private int maxHealth = 3;
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
            if (value<= MaxHealth)
            {
                if(value < currentHealth)
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

    
       
    public bool isInvincible { get; set; }

    void Awake()
    {
        currentHealth = MaxHealth;
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Hurt(int damage, Vector2 knockback)
    {
        currentHealth -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    void Update()
    {

    }
}
