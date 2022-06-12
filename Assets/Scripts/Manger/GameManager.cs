using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; } = null;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
