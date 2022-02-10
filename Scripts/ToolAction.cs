using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ToolAction : MonoBehaviour
{
    public void Action(ToolItemObject.ToolType toolType, int range, int power, int rank, FacingDirection.Direction dir, Vector3 playerPosition)
    {
        if (toolType == ToolItemObject.ToolType.Glove)
        {

        }

        if (toolType == ToolItemObject.ToolType.Jug)
        {

        }

        if (toolType == ToolItemObject.ToolType.Pickaxe)
        {

            gameObject.GetComponent<Mine>().MineAction(range, power, rank, dir, playerPosition);
        }
    }
}
