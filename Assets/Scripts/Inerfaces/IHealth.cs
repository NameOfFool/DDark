using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public int MaxHealth{get;set;}
    public int CurrentHealth{get; set;}
    public bool isInvincible{get;set;}

    //TODO Invincible animation
    public void Death()
    {

    }

    public void Hurt(int damage, Vector2 knockback)
    {
    }

}