using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public float[] einrastPunkte = { 26.6f, 0f, -26.6f };
    public GameObject[] waffen = new GameObject[3];

    public PlayerShoot ps;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            index++;
            Vector3 selectorPos = gameObject.transform.localPosition;
            selectorPos.y = einrastPunkte[index % einrastPunkte.Length];
            gameObject.transform.localPosition = selectorPos;

            ps.ChangeProjectile(waffen[index % einrastPunkte.Length]);
        }
    }
}
