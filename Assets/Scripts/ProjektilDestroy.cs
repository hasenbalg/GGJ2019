using UnityEngine;

public class ProjektilDestroy : MonoBehaviour
{
    public float maxDistance = 200f;
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position ) > maxDistance) {
            Destroy(gameObject);
        }
    }
}
