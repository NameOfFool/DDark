using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : Item
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
    public override void Interact(GameObject src)
    {
        src.GetComponent<Inventory>().inventory.AddRightArmItem(item);
        Destroy(gameObject);
    }
}
