using UnityEngine;
using System.Collections;

public class ProjektilDestroy : MonoBehaviour
{
    public float maxDistance = 200f;
    public Transform player;
    private float timer;

    void Start()
    {
        timer = Time.realtimeSinceStartup;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position ) > maxDistance || Time.realtimeSinceStartup > timer + 1 ) {
            Destroy(gameObject);
        }
    }
}
