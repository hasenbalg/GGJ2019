using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{

    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
