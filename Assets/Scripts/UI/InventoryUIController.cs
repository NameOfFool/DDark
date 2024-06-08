using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
    public List<UIInventorySlot> slots = new List<UIInventorySlot>();
    public UIInventorySlot RightArmSlot;
    public UIInventorySlot LeftArmSlot;
    public UIInventorySlot ArmorSlot;
    public InventoryObject PlayerInventory;
    private VisualElement m_Root;
    private VisualElement m_SlotContainer;
    private VisualElement m_EquipmentConainer;
    private const string SlotContainer = "SlotContainer";
    private const string EquipmentContainer = "EquipmentContainer";
    [SerializeField] private InputReader m_InputReader;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        InventoryClose();

        m_EquipmentConainer = m_Root.Q<VisualElement>(EquipmentContainer);
        m_SlotContainer = m_Root.Q<VisualElement>(SlotContainer);

        RightArmSlot = new UIInventorySlot();
        m_EquipmentConainer.Add(RightArmSlot);
        if(PlayerInventory.RightArmSlot != null)
            OnRightArmItemAdded();

        LeftArmSlot = new UIInventorySlot();
        m_EquipmentConainer.Add(LeftArmSlot);

        ArmorSlot = new UIInventorySlot();
        m_EquipmentConainer.Add(ArmorSlot);

        for (int i = 0; i < 20; i++)
        {
            UIInventorySlot item = new UIInventorySlot();
            if (PlayerInventory.Slots.Count > i)
            {
                item.HoldItem(PlayerInventory.Slots[i].item);
            }
            slots.Add(item);
            m_SlotContainer.Add(item);
        }

        PlayerInventory.ItemAdded += OnItemAdded;
        PlayerInventory.RightArmItemAdded +=OnRightArmItemAdded;
    }
    private void InventoryToggle()//TO think: United UI Menu
    {
        if (m_Root.enabledSelf)
        {
            InventoryClose();
        }
        else
        {
            InventoryOpen();
        }
    }
    private void InventoryOpen()
    {
        m_Root.style.opacity = 1;
        m_Root.SetEnabled(true);
    }
    private void InventoryClose()
    {
        m_Root.style.opacity = 0;
        m_Root.SetEnabled(false);
    }
    #region Unity Event
    private void OnInventoryOpen()
    {
        InventoryToggle();
    }
    private void OnEnable()
    {
        m_InputReader.InventoryInput += OnInventoryOpen;
    }
    private void OnDisable()
    {
        m_InputReader.InventoryInput -= OnInventoryOpen;
    }
    private void OnItemAdded()
    {
        int index = PlayerInventory.Slots.Count - 1;
        slots[index].HoldItem(PlayerInventory.Slots[index].item);
    }
    private void OnRightArmItemAdded()
    {
        RightArmSlot.HoldItem(PlayerInventory.RightArmSlot.item);
    }
    #endregion
}
