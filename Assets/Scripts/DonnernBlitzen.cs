using System.Collections;
using UnityEngine;

public class DonnernBlitzen : MonoBehaviour
{
    private IEnumerator coroutine;
    private MeshRenderer mr;
    public float interval = 2f;
    public MeshRenderer targetMr;

    void Start()
    {
        coroutine = OnOff(interval);
        StartCoroutine(coroutine);
    }

    private IEnumerator OnOff(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            targetMr.enabled = !targetMr.enabled;
        }
    }
}
