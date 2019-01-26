using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text score;

    public Image haus;
    private float stimmungInitTotat;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Family"))
        {
            stimmungInitTotat += go.GetComponent<Stimmung>().stimmung;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "";
        //"Score: " + Mathf.Round(Time.realtimeSinceStartup);
        float stimmungSum = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Family")) {
            stimmungSum += go.GetComponent<Stimmung>().stimmung;
        }
        Vector3 hausRot = haus.rectTransform.eulerAngles;
        hausRot.z = (stimmungInitTotat - stimmungSum) / 45;
        haus.rectTransform.eulerAngles = hausRot;
    }
}
