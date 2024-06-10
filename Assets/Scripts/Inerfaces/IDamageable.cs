using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool isInvincible { get; set; }
    public UnityEvent OnBegin { get; set; }
    public UnityEvent OnDone { get; set; }
    public float GetHealthPercent()
    {
        return CurrentHealth / MaxHealth * 100;
    }

    public void Die()
    {

    }

    public void Hurt(float damage, Vector2 knockback)
    {
    }
    public IEnumerator ResetVelocity();

}