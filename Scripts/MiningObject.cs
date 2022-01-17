using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Mining Object", menuName = "Mining System/Mining Object")]

public class MiningObject : ScriptableObject
{
    [SerializeField]
    private int toolRankReq;
    [SerializeField]
    private GameObject lootDrop;
    [SerializeField]
    private int hitsReq;
    [SerializeField]
    private GameObject prefab;

    public void Mine(ToolItemObject tool)
    {
        if (tool.toolType == ToolItemObject.ToolType.Pickaxe)
        {
            
            if (tool.rank >= toolRankReq)
            {
                hitsReq -= tool.toolPower;

                if (hitsReq <= 0)
                {
                    Instantiate(lootDrop);
                    Destroy(prefab);
                }
            }
        }
    }
}
