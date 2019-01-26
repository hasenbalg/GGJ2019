using UnityEngine;

public class Stimmung : MonoBehaviour
{
    public float stimmung = 1000;
    [Tooltip("Muss weniger als Stimmung sein.")]
    public float minStimmung = 0;


    // Start is called before the first frame update
    public void nimmSchaden(float schaden)
    {
        stimmung -= schaden;
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
           // hier muessen die verschiedenen Arten der Munition abgefragt und verrechnet werden
            if (contact.otherCollider.CompareTag("Projektile")) {
                stimmung++;
            }
        }
    }
}
