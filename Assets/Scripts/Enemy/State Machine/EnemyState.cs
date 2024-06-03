using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }
    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void PhysicalUpdate(){}
    public virtual void FrameUpdate(){}
    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType trigger){}
}
