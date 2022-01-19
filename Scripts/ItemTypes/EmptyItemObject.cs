using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Empty Object", menuName = "Inventory System/Items/Empty")]

public class EmptyItemObject : ItemObject
{


    private void Awake()
    {
        type = ItemType.Empty;
    }
}
