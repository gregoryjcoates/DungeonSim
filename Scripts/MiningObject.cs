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
    private int hitsReq;
    [SerializeField]
    private GameObject prefab;
    // test
    [SerializeField]
    private List<GameObject> loot;
    [SerializeField]
    private List<int> lootWeights;

    

  

    public int Mine(int power, int rank)
    {
        
        if (rank >= toolRankReq)
        {
            hitsReq -= power;

            if (hitsReq <= 0)
            {
                // it dead
                return 0;
            }
            else
            {
                // was hit but still alive
                return 1;
            }
        }
        else
        {
            // tool fails to work
            return -1;
        }
    }

    public GameObject GetDrop()
    {
        return DropTable.DropLoot(loot, lootWeights);
    }
}

