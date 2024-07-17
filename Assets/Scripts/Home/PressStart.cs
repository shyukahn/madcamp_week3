// Home scene start button -> scene select
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PressStart : MonoBehaviour
{
    public GameObject EndScreen;
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
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ShowExit()
    {
        EndScreen.SetActive(true);
    }
    public void CancelExit()
    {
        EndScreen.SetActive(false);
    }
}
