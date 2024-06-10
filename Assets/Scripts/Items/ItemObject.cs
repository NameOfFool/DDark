using UnityEngine;

public enum ItemType
{
    Default,
    Tool
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
    public ItemType type;
}
