using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        transform.parent.GetComponent<SwordItem>().HurtTarget(col);
    }
}
