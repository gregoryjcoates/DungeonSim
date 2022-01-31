using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position;
    }
}
