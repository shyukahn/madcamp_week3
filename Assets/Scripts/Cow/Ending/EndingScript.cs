using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public GameObject end1;
    public GameObject end2;
    public GameObject end3;
    public GameObject dirtTilemap;
    IEnumerator StartEnding()
    {
        end1.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        end2.SetActive(true);
        dirtTilemap.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        end1.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        end3.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEnding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
