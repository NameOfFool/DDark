using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";
    public InventorySlot()
    {
        Icon = new Image();
        Icon.AddToClassList("SlotIcon");
        AddToClassList("slotContainer");
    }
    #region UXML
    public new class UxmlFactory : UxmlFactory<InventorySlot,UxmlTraits>{}
    public new class UxmlTraits : VisualElement.UxmlTraits{}
    #endregion
}
