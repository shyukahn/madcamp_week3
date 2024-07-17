using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void ToTurtle()
    {
        SceneManager.LoadScene("Turtle");
    }
    public void ToPolarbear()
    {
        SceneManager.LoadScene("PolarbearScene");
    }
    public void ToCow()
    {
        SceneManager.LoadScene("CowScene");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("Home Scene");
    }
}
