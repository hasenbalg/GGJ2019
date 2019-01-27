using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text score;

    public Image haus;
    private float stimmungInitTotal;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {

        //Time.timeScale = 10f;


        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Family"))
        {
            stimmungInitTotal += go.GetComponent<Stimmung>().stimmung;
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
        hausRot.z = (stimmungInitTotal - stimmungSum)/ stimmungInitTotal * 45;
        haus.rectTransform.eulerAngles = hausRot;

        if (stimmungSum <= 0 && !gameOver) {
            Vector2 hausZentrumAnchorMin = haus.rectTransform.anchorMax;
            hausZentrumAnchorMin.y = .5f;
            haus.rectTransform.anchorMin = hausZentrumAnchorMin;

            Vector2 hausZentrumAnchorMax = haus.rectTransform.anchorMax;
            hausZentrumAnchorMax.y = .5f;
            haus.rectTransform.anchorMax = hausZentrumAnchorMax;

            gameOver = true;
        } else if (gameOver) {
            haus.transform.position = Vector2.MoveTowards(haus.transform.position, Vector2.zero, .01f * Time.deltaTime);

            if (Vector2.Distance(haus.transform.position, Vector2.zero) < .01f) {
                SceneManager.LoadScene(2);
            }
        }

    }


}
