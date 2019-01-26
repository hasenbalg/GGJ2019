using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannStimmung : Stimmung
{
    public float rotWerdenSchwellenwert = 500;

    public Texture rot;
    public GameObject sprite;
    private EinfacheAnimation ea;
    // Start is called before the first frame update
    void Start()
    {
        ea = sprite.GetComponent<EinfacheAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stimmung < rotWerdenSchwellenwert)
        {
            ea.enabled = false;
            sprite.GetComponent<Renderer>().material.mainTexture = rot;
        }
        

        if (stimmung < minStimmung)
        {
            DestroyImmediate(gameObject);
        }
       
    }

}
