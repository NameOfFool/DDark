using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainArmController : MonoBehaviour
{
    private SwordItem item;
    public SwordItem Item
    {
        get => item;
        set
        {
            item = value;
            item.gameObject.transform.SetParent(transform);
            item.gameObject.transform.localPosition = new(0.3f,0.06f);
            item.gameObject.transform.localRotation = new Quaternion(0,0,0,0);
            item.gameObject.transform.localScale = new(1,1,1);
        }
    }
    public void Attack()
    {
        try
        {
            Item.Attack();
        }
        catch
        {

        }
    }
}
