using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : MonoBehaviour
{
    void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IHealth health))
        {
            health.CurrentHealth-=1;
        }
    }
}
