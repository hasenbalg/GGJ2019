using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeindeSpawnen : MonoBehaviour
{
    public GameObject[] feinde;
    public int maxNum = 5;

    void Start()
    {
        for (int i = 0; i < maxNum; i++) {

            GameObject go = feinde[Random.Range(0, feinde.Length)];
            Instantiate(
                go, new Vector3(
                Random.Range(-10.0f, 10.0f),
                go.transform.position.y,
                Random.Range(-10.0f, 10.0f)
                ),
                Quaternion.identity
                );
        }
    }
    private void Update()
    {
          if (GameObject.FindGameObjectsWithTag("Feinde").Length < maxNum) {
            int index = Random.Range(0, feinde.Length);
            GameObject go = feinde[index];
            Debug.Log("index: " + index);
            Debug.Log("length: " + feinde.Length);
            Debug.Log("pop");
            Instantiate(
                go, new Vector3(
                Random.Range(-10.0f, 10.0f),
                go.transform.position.y,
                Random.Range(-10.0f, 10.0f)
                ),
                Quaternion.identity
                );
        }
    }
}
