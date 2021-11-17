using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static public bool isEasy = false;
    static public bool isMedium = false;
    static public bool isHard = false;

    public void PlayGameEasy()
    {
        isEasy = true;
        SceneManager.LoadScene(1);
    }

    public void PlayGameMedium()
    {
        isMedium = true;
        SceneManager.LoadScene(1);
    }

    public void PlayGameHard()
    {
        isHard = true;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void TestSuite()
    {
        SceneManager.LoadScene(4);
    }
}
