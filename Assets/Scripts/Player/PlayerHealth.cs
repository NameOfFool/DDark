using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private Animator _anim;
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

    [SerializeField] private uint invincibleTime;
    public uint InvincibleTime {get=> invincibleTime;set=> invincibleTime = value;}

    void Awake()
    {
        currentHealth = MaxHealth;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
