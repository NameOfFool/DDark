using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable 
{
    bool isChasing{get;set;}
    bool canAttack{get;set;}
    void SetChaseStatus(bool status);
    void SetAttackStatus(bool status);
}