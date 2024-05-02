using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

    public uint InvincibleTime {get;set;}

    void Awake()
    {
        currentHealth = MaxHealth;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
