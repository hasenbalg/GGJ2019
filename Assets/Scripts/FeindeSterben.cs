using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeindeSterben : MonoBehaviour
{
    public float lebenspunkte = 50;

    public float schwellenwertVorSprite = 10;

    public Texture sterbeSprite;
    public GameObject sprite;
    private EinfacheAnimation ea;

    void Start()
    {
        ea = sprite.GetComponent<EinfacheAnimation>();
    }

    // Start is called before the first frame update
    public void nimmSchaden(float schaden)
    {
        lebenspunkte -= schaden;
    }

    // Update is called once per frame
    void Update()
    {
        if (lebenspunkte <= schwellenwertVorSprite && sterbeSprite != null && ea != null)
        {
            ea.enabled = false;
            sprite.GetComponent<Renderer>().material.mainTexture = sterbeSprite;
        }
        if (lebenspunkte <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // hier muessen die verschiedenen Arten der Munition abgefragt und verrechnet werden
            if (contact.otherCollider.CompareTag("Projektile"))
            {
                lebenspunkte--;
            }
        }
    }
}
