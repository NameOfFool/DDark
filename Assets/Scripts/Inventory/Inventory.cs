using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;
    [SerializeField]private GameObject RightArm;
    [SerializeField]private GameObject LeftArm;
    private void Awake()
    {
        if(inventory.RightArmSlot!=null)
        {
            OnRightArmItemAdded();
        }
    }    
    #region Unuty Events
    private void OnEnable()
    {
        inventory.RightArmItemAdded +=OnRightArmItemAdded;
    }
    private void OnDisable()
    {
        inventory.RightArmItemAdded -=OnRightArmItemAdded;
    }
    private void OnRightArmItemAdded()
    {
        Instantiate(inventory.RightArmSlot.item.prefab,RightArm.transform.position, Quaternion.identity,RightArm.transform);        
    }
    #endregion
}
