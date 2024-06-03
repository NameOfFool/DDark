using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void HurtTarget(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable health))
        {
            health.Hurt(1, new Vector2(transform.lossyScale.x * 5, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out MainArmController arm))
        {
            arm.Item = this;
        }
    }
}
