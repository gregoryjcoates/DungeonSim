using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropTable
{

    // roll for loot via weight
    public static GameObject DropLoot(List<GameObject> lootObs, List<int> lootWeights)
    {

        GameObject drop = null;

        int totalWeight = 0;

        SortedList<int,GameObject> sortedLoot = new SortedList<int, GameObject>();

        for (int i = 0; i < lootWeights.Count; i++)
        {
            sortedLoot.Add(lootWeights[i], lootObs[i]);
        }


        foreach (int weight in lootWeights)
        {
            totalWeight += weight;
        }

        int roll = Random.Range(0, totalWeight + 1 );
        Debug.Log("Roll is" + roll);
        for (int i = 0; i < lootObs.Count ; i++)
        {
            Debug.Log("this is i:" + i);
            Debug.Log(sortedLoot.Keys[i]);
            if (roll <= sortedLoot.Keys[i])
            {

                Debug.Log("loot is " + sortedLoot.Values[i]);
                drop = sortedLoot.Values[i];
            }
            // if the roll is at or above the weight for the highest chance object, drop it
            else if (sortedLoot.Keys[i] == sortedLoot.Keys[sortedLoot.Count - 1])
            {
                drop = sortedLoot.Values[i];
            }
        }

        return drop;
    }
}
