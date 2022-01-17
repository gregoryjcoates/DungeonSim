using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New PlayerFood Object", menuName = "Inventory System/Items/PlayerFood")]

public class PlayerFoodItemObject : ItemObject
{
    [SerializeField]
    protected int manaRecovery;

    public void Awake()
    {
        type = ItemType.PlayerFood;
    }
}