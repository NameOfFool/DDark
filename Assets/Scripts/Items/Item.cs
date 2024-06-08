using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemObject item;
    public virtual void Interact(GameObject src)//TODO Split items and weapon
    {
        src.GetComponent<Inventory>().inventory.AddItem(item);
        Destroy(gameObject);
    }
}
