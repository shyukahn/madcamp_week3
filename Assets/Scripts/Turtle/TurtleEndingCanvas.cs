using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TurtleEndingCanvas : MonoBehaviour
{
    public GameObject continueText;
    public InputAction endAction;
    public Canvas nextCanvas;
    public Canvas result1Canvas;
    public Canvas result2Canvas;
    public Canvas result3Canvas;
    public Canvas lastCanvas;

    IEnumerator EnableNextCanvas()
    {
        yield return new WaitForSeconds(0.7f);
        nextCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        nextCanvas.gameObject.SetActive(false);
        result1Canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        result1Canvas.gameObject.SetActive(false);
        result2Canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        result2Canvas.gameObject.SetActive(false);
        result3Canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        result3Canvas.gameObject.SetActive(false);
        lastCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    IEnumerator ShowContinueText()
    {
        yield return new WaitForSeconds(1.0f);
        endAction.Enable();
        while (true) {
            if (continueText.activeInHierarchy) {
                continueText.SetActive(false);
            } else {
                continueText.SetActive(true);
            }
            yield return new WaitForSeconds(0.75f);
        }        
    }
    void Start()
    {
        StartCoroutine(ShowContinueText());
    }

    // Update is called once per frame
    void Update()
    {
        if (endAction.enabled && endAction.IsPressed())
        {
            StopAllCoroutines();
            StartCoroutine(EnableNextCanvas());
            endAction.Disable();
        }
    }
}