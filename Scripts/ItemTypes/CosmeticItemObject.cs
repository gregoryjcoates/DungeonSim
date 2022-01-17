using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cosmetic Object", menuName = "Inventory System/Items/CosmeticItem")]
public class CosmeticItemObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Cosmetic;
    }
}
