using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{
    UnityEvent myEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        myEvent.AddListener(test);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            myEvent.Invoke();
        } 
    }

    void test()
    {
        Debug.Log("It worked fucker");
    }
}
