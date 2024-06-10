using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public event UnityAction ItemAdded;
    public event UnityAction RightArmItemAdded;
    public event UnityAction LeftArmItemAdded;
    public event UnityAction ArmorItemAdded;
    public List<InventorySlot> Slots = new List<InventorySlot>();
    public InventorySlot RightArmSlot;
    public InventorySlot LeftArmSlot;
    public InventorySlot ArmorSlot;
    public void AddItem(ItemObject item)
    {
        Slots.Add(new InventorySlot(item));
        ItemAdded.Invoke();
    }
    public void AddRightArmItem(ItemObject item)
    {
        RightArmSlot = new InventorySlot(item);
        RightArmItemAdded.Invoke();
    }
    public void AddLeftArmItem(ItemObject item)
    {
        LeftArmSlot = new InventorySlot(item);
        LeftArmItemAdded.Invoke();
    }
    public void AddArmor(ItemObject item)
    {
        ArmorSlot = new InventorySlot(item);
        ArmorItemAdded.Invoke();
    }
}
[Serializable]
public class InventorySlot//TODO Exitend for amountable and breakable items
{
    public ItemObject item;
    public InventorySlot(ItemObject itemObject)
    {
        item = itemObject;
    }
}
