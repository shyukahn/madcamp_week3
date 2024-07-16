using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CowStartScreen : MonoBehaviour
{
    public GameObject continueText;
    public InputAction startAction;
    public GameObject player;
    public GameObject gameManager;
    IEnumerator ShowContinueText()
    {
        yield return new WaitForSeconds(1.0f);
        startAction.Enable();
        while (true) {
            if (continueText.activeInHierarchy) {
                continueText.SetActive(false);
            } else {
                continueText.SetActive(true);
            }
            yield return new WaitForSeconds(0.75f);
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowContinueText());
    }

    // Update is called once per frame
    void Update()
    {
        if (startAction.enabled && startAction.IsPressed()) {
            StopAllCoroutines();
            gameManager.SetActive(true);
            player.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
