using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableObject : MonoBehaviour
{
    [SerializeField]
    private MiningObject mineOb;
    public MiningObject instance;

    private void Awake()
    {
        instance = Instantiate(mineOb);
    }

}

