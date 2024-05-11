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
            //item.gameObject.transform.position = gameObject.transform.position;
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
