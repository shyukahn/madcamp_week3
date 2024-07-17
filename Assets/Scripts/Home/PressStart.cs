// Home scene start button -> scene select
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PressStart : MonoBehaviour
{
    public void ToSceneSelect()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
    public void ToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("Home Scene");
    }
}
