using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour, IHealth
{
[SerializeField] private int maxHealth = 3;
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
    private int currentHealth;
    public uint InvincibleTime {get;set;}
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value<= MaxHealth)
            {
                if(value < currentHealth)
                {
                    Death();
                }
                if (value > 0)
                    currentHealth = value;
                else
                    currentHealth = 0;
            }
        }
    }
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        
    }
}
