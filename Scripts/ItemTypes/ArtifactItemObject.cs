using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Artifact Object", menuName = "Inventory System/Items/Artifact")]

public class ArtifactItemObject : ItemObject
{
    [SerializeField]
    protected GameObject function;

    public void Awake()
    {
        type = ItemType.Artifact;
    }
}
