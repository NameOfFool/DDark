using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState {get;set;}
    public void Initialize(EnemyState defaultState)
    {
        CurrentState = defaultState;
        defaultState.EnterState();
    }
    public void ChangeState(EnemyState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        newState.EnterState();
    }
}
