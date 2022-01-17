using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Feed Object", menuName = "Inventory System/Items/Feed")]

public class FeedItemObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Feed;
    }
}
