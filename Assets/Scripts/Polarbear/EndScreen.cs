using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject continueText;
    IEnumerator ShowContinueText()
    {
        yield return new WaitForSeconds(2.0f);
        while (true) {
            if (continueText.activeInHierarchy) {
                continueText.SetActive(false);
            } else {
                continueText.SetActive(true);
            }
            yield return new WaitForSeconds(1.0f);
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
        
    }
}
