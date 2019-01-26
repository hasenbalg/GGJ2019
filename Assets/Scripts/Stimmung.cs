using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimmung : MonoBehaviour
{
    public float stimmung = 1000;
    [Tooltip("Muss weniger als Stimmung sein.")]
    public float minStimmung = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stimmung < minStimmung) {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.otherCollider.CompareTag("Projektile")) {
                stimmung++;
            }
        }
    }
}
