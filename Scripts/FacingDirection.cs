using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingDirection : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Right,
        Left,
        Down
    }

    public Direction facingDir = Direction.Down;

    public Direction DirectionFacing( float x, float y)
    {
        
        if (x > 0)
        {
            facingDir = Direction.Right;
        }

        if (x < 0)
        {
            facingDir = Direction.Left;
        }

        if (y > 0)
        {
            facingDir = Direction.Up;
        }

        if (y < 0)
        {
            facingDir = Direction.Down;
        }

        return facingDir;
    }
}
