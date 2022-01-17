using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Object", menuName = "Inventory System/Items/Tool")]

public class ToolItemObject : ItemObject
{
    public enum ToolType
    {
        Glove,
        Jug,
        Pickaxe
    }

    [SerializeField]
    protected GameObject function;
    [SerializeField]
    public ToolType toolType;
    [SerializeField]
    public int toolPower;
    [SerializeField]
    public int toolRange;

    private void Awake()
    {
        type = ItemType.Tool;
    }
}
