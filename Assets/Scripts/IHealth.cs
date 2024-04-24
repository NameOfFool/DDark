using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public int MaxHealth{get;set;}
    public int CurrentHealth{get; set;}
    public uint InvincibleTime{get;set;}
    //TODO Invimcible animation
    public void Death()
    {

    }

}