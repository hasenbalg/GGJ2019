using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWolke : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public float flightHeight;
    [Tooltip("Beinhaltet die Flughoehe")]
    public float reach = 2f;

    public float machtSchaden = 1;


    void Start()
    {
        flightHeight = transform.position.y;
        target = FindClosestEnemy().transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        GameObject target = FindClosestEnemy();

        if (target != null)
        {
            //wolke oben halten
            Vector3 targetPos = target.transform.position;
            targetPos.y = flightHeight;
            

            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, target.transform.position) < reach)
            {
                // DONNERN mit PFEILEN
                // FAMILIENMITGLIED AERGERN

                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Family")) {
                    go.GetComponent<DonnernBlitzen>().enabled = false;
                }
                if (target.CompareTag("Family"))
                {
                    target.GetComponent<Stimmung>().nimmSchaden(machtSchaden);
                    target.GetComponent<DonnernBlitzen>().enabled = true;
                }
                
                target = FindClosestEnemy();
            }
        }

    }


    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Family");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
