using System.Collections;
using UnityEngine;

public class EinfacheAnimation : MonoBehaviour
{
    private IEnumerator coroutine;
    public Texture[] textures;
    private int counter;
    private Renderer mRenderer;
    public float interval = .5f;

    void Start()
    {
        coroutine = ChangeSprite(interval);
        counter = 0;
        StartCoroutine(coroutine);
        mRenderer = GetComponent<Renderer>();
    }

    private IEnumerator ChangeSprite(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            mRenderer.material.mainTexture = textures[counter % textures.Length ];
            counter++;
        }
    }
}
