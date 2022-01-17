using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject cam;
    private GameObject cameraTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create camera game object and set parameters
        cam = new GameObject("cam");
        cam.transform.position = new Vector3(0,0,-10);
        cam.AddComponent<Camera>();
        Camera camR = cam.GetComponent<Camera>();
        cam.tag = "MainCamera";
        camR.orthographic = true;
        camR.orthographicSize = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        // set position to player or other object position
        cam.transform.position = new Vector3(cameraTarget.transform.position.x,cameraTarget.transform.position.y,-10);
    }

    // set the object the camera will focus on
    public void ObjectToFollow(GameObject target)
    {
        cameraTarget = target;
    }
}
