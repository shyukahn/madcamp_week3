// Home scene start button -> scene select
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToCow : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("CowScene");
    }
}
