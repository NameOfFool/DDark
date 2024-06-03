using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _target;
    private Vector3 _direction;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        _target = GetRandomPointInCircle();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(enemy.isChasing)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
        _direction = (_target - enemy.transform.position).normalized;
        enemy.Move(_direction);
        if((enemy.transform.position - _target).sqrMagnitude < 0.01f)
        {
            _target = GetRandomPointInCircle();
        }
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType trigger)
    {
    }
    public Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
    }
}
