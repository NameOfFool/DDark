using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    public int MaxHealth{get;set;}
    public int CurrentHealth{get; set;}
    public bool isInvincible{get;set;}
    public UnityEvent OnBegin{get;set;}
    public UnityEvent  OnDone{get;set;}

    public void Death()
    {

    }

    public void Hurt(int damage, Vector2 knockback)
    {
    }
    public IEnumerator ResetVelocity();

}