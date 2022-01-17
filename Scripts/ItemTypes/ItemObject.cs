using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Artifact,
    Loot,
    Tool,
    Feed,
    Trap,
    PlayerFood,
    Cosmetic
}

public abstract class ItemObject : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    public ItemType type;
    [SerializeField]
    public int rank;
    [SerializeField]
    protected bool craftingResource;
    [TextArea(15, 20)]
    public string description;
    [SerializeField]
    public int dropQuantity;

}
