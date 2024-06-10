using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
    public List<UIInventorySlot> slots = new List<UIInventorySlot>();
    private static VisualElement m_GhostIcon;
    private static bool m_IsDragging;
    private static UIInventorySlot m_OriginalSlot;
    public UIInventorySlot RightArmSlot;
    public UIInventorySlot LeftArmSlot;
    public UIInventorySlot ArmorSlot;
    public InventoryObject PlayerInventory;
    private VisualElement m_Root;
    private VisualElement m_Inventory;
    private VisualElement m_SlotContainer;
    private VisualElement m_EquipmentConainer;
    private const string SlotContainer = "SlotContainer";
    private const string InventoryContainer = "Inventory";
    private const string EquipmentContainer = "EquipmentContainer";
    private const string GhotsIcon = "GhotsIcon";
    private ProgressBar m_HealthBar;
    [SerializeField] private InputReader m_InputReader;
    private void Awake()
    {
        Init();
        //TODO REPLACE TO ANOTHER SCRIPT
        m_HealthBar = m_Root.Q<ProgressBar>("PlayerHealth");
    }
    public void Init()
    {
        m_Root = GetComponent<UIDocument>().rootVisualElement;

        m_Inventory = m_Root.Q<VisualElement>(InventoryContainer);
        m_EquipmentConainer = m_Root.Q<VisualElement>(EquipmentContainer);
        m_SlotContainer = m_Root.Q<VisualElement>(SlotContainer);
        m_GhostIcon = m_Root.Q<VisualElement>(GhotsIcon);
        InventoryClose();

        RightArmSlot = new UIInventorySlot();
        m_EquipmentConainer.Add(RightArmSlot);
        if (PlayerInventory.RightArmSlot != null)
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
        PlayerInventory.RightArmItemAdded += OnRightArmItemAdded;
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
        m_Inventory.style.opacity = 1;
        m_Inventory.SetEnabled(true);
    }
    private void InventoryClose()
    {
        m_Inventory.style.opacity = 0;
        m_Inventory.SetEnabled(false);
    }
    //TODO!!! Place to another script
    #region HealthConroller
    [SerializeField] private PlayerHealth m_playerHealth;
    private void OnPlayerHealthChanged()
    {
        m_HealthBar.value = m_playerHealth.GetHealthPercent();
        
        Debug.Log(m_HealthBar.value);
    }
    #endregion
    #region Unity Event
    private void OnInventoryOpen()
    {
        InventoryToggle();
    }
    private void OnEnable()
    {
        m_InputReader.InventoryInput += OnInventoryOpen;
        m_playerHealth.OnPlayerDamaged += OnPlayerHealthChanged;
        m_playerHealth.Hurt(50f);
    }
    private void OnDisable()
    {
        m_InputReader.InventoryInput -= OnInventoryOpen;
        m_playerHealth.OnPlayerDamaged += OnPlayerHealthChanged;
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
