using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Load in the different levels
    public void SplashScreen()
    {
        SceneManager.LoadScene("Intro_Scene");
    }

    //Load main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    //Load level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }    
}
