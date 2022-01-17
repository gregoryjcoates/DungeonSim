using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot Object", menuName = "Inventory System/Items/Loot")]

public class LootItemObject : ItemObject
{
    [Tooltip("Low, Medium, Or High")]
    [SerializeField]
    protected string Value; 

    private void Awake()
    {
        type = ItemType.Loot;
    }
}
