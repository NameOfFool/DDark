using UnityEngine.UIElements;

public class UIInventorySlot : VisualElement
{
    public Image Icon;
    public ItemObject item;
    public string ItemGuid = "";
    public UIInventorySlot()
    {
        Icon = new Image();
        Add(Icon);
        Icon.AddToClassList("SlotIcon");
        AddToClassList("slotContainer");
    }
    public void HoldItem(ItemObject item)
    {
        Icon.image = item.icon.texture;
        this.item = item;
    }
    public void DropItem()
    {

    }
    #region UXML
    public new class UxmlFactory : UxmlFactory<UIInventorySlot,UxmlTraits>{}
    public new class UxmlTraits : VisualElement.UxmlTraits{}
    #endregion
}
