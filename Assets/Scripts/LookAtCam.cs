using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{

    public Camera cam;
    

    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        transform.LookAt(cam.transform);
        Vector3 rotation = transform.eulerAngles;
        rotation.x = 0;
        rotation.y += 180;
        rotation.z = 0;
        transform.eulerAngles = rotation;
    }
}
