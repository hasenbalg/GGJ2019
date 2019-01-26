using System.Collections;
using UnityEngine;

public class EinfacheAnimation : MonoBehaviour
{
    private IEnumerator coroutine;
    public Texture[] textures;
    private int counter;
    private Renderer renderer;
    public float interval = .5f;

    void Start()
    {
        coroutine = ChangeSprite(interval);
        counter = 0;
        StartCoroutine(coroutine);
        renderer = GetComponent<Renderer>();
    }

    private IEnumerator ChangeSprite(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            renderer.material.mainTexture = textures[counter % textures.Length ];
            counter++;
        }
    }
}
