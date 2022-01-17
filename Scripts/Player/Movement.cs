using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{



    public Vector2 Move(Rigidbody2D rb, float speed, float x, float y)
    {
        return new Vector2(x * speed, y * speed );
    }

}
