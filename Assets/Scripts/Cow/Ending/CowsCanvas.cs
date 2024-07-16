using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CowsCanvas : MonoBehaviour
{
    IEnumerator StartCows()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCows());
    }
}
