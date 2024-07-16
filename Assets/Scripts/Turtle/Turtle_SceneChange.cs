// Turtle Main Scene -> Ending Scene when button onPressed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turtle_SceneChange : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("TurtleEnding");
    }
}
