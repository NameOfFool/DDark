using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public int MaxHealth{get;set;}
    public int CurrentHealth{get; set;}
<<<<<<< HEAD
    public bool isInvincible{get;set;}

    //TODO Invimcible animation
=======
    public uint InvincibleTime{get;set;}
    //TODO Invincible animation
>>>>>>> ae22b48 (sav)
    public void Death()
    {

    }

    public void Hurt(int damage, Vector2 knockback)
    {
    }

}