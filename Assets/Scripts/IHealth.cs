using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public int MaxHealth{get;set;}
    public int CurrentHealth{get;protected set;}
    public void ReduceCurrentHealth()
    {
        CurrentHealth-=1;
    }
}
