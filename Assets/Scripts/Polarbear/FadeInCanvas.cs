using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInCanvas : MonoBehaviour
{
    public float fadeTime;
    private CanvasGroup canvasGroup;
    private float accumTime = 0.0f;
    IEnumerator FadeIn()
    {
        while (accumTime < fadeTime) {
            canvasGroup.alpha = accumTime / fadeTime;
            yield return null;
            accumTime += Time.deltaTime;        
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    void Start()
    {
        StartCoroutine(FadeIn());
    }
}
