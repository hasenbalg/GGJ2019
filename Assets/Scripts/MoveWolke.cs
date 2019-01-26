using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWolke : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public float flightHeight;
    public float reach = 2f;
    // Start is called before the first frame update
    void Start()
    {
        flightHeight = transform.position.y;
        target = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        Vector3 target = FindClosestEnemy();
        target.y = flightHeight;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < reach)
        {
            // DONNERN mit PFEILEN
            // FAMILIENMITGLIED AERGERN
            target = FindClosestEnemy();
        }
    }

   
    public Vector3 FindClosestEnemy()
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
        return closest.transform.position;
    }
}
