using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{

    public GameObject player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 rotation = transform.eulerAngles;
        rotation.x = 0;
        rotation.y += 180;
        rotation.z = 0;
        transform.eulerAngles = rotation;
    }
}
