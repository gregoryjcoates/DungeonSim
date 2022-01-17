using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trap Object", menuName = "Inventory System/Items/Trap")]

public class TrapItemObject : ItemObject
{
    [Tooltip("The strength of the trap. Low, Medium, or High")]
    [SerializeField]
    protected string strength;

    [Tooltip("The damage the trap does")]
    [SerializeField]
    protected int damage;

    private void Awake()
    {
        type = ItemType.Trap;
    }
}
