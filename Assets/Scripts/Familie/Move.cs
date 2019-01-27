using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    private float initialY;
    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        target = FindTarget();
    }

    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            // Swap the position of the cylinder.
            target = FindTarget();
        }
    }

    Vector3 FindTarget() {
        Vector3 newTarget = new Vector3(Random.Range(-10.0f, 10.0f), initialY, Random.Range(-10.0f, 10.0f));
        return newTarget;
    }
}
