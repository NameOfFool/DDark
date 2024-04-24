using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D))]
public class AIVision : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent _agent;
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        _agent.SetDestination(target.position);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.TryGetComponent(out IHealth health))
        {
            health.CurrentHealth-=1;
        }
    }
}
