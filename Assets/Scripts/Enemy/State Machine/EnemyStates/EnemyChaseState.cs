using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private Transform _playerTransform;
    private float _movementSpeed = 0.75f;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override void EnterState()
    {
    }
    public override void ExitState()
    {
    }
    public override void PhysicalUpdate()
    {
    }
    public override void FrameUpdate()
    {
        if(!enemy.isChasing)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        Vector2 direction = (_playerTransform.position - enemy.transform.position).normalized;
        enemy.Move(direction * _movementSpeed);
    }
}
