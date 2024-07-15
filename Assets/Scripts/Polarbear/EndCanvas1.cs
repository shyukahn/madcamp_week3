using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCanvas1 : MonoBehaviour
{
    public Canvas nextCanvas;
    public Canvas thirdCanvas;
    IEnumerator EnableNextCanvas()
    {
        yield return new WaitForSeconds(8.5f);
        nextCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        thirdCanvas.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableNextCanvas());
    }
}
