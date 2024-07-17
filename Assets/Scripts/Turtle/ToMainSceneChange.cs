// Turtle Result Last Scene -> Home Scene when button onPressed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainSceneChange : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Home Scene");
    }
}
