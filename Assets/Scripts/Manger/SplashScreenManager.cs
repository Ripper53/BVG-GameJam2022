using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    //Blackscreen for fade in fade out
    public Image BlackScreen;

    //Colour used for the screen fade
    private Color colour;

    //Images to be displayed
    public GameObject BVGLogoImage;
    public GameObject BackgroundNameImage;
    public GameObject GameNameImage;

    //Fade rate
    public float FadeRate;

    //Timer
    private float timer;
    
    //Name of the main menu level to be loaded
    public string MainMenu;

    //Sounds
    private GameObject soundControllerObject;

    private int songIndex = 0;
    private int sfxIndex = 0;

    private bool playSFXOnce = true;

    [Range(0.0f, 1.0f)]
    public float MusicVolumne = 0.5f;

    [Range(0.0f, 1.0f)]
    public float SFXVolumne = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //Start with a black screen
        colour = BlackScreen.color;
        colour.a = 1;
        BlackScreen.color = colour;
        BlackScreen.gameObject.SetActive(true);
        
        //Show the BVG Logo First 
        ShowGameBackgroundImage(false);
        ShowBVGLogoImage(true);
        ShowGameNameImage(false);

        //Setup the music
        soundControllerObject = GameObject.Find("SoundController");
        soundControllerObject.SendMessage("PlayMusic", songIndex);

        soundControllerObject.SendMessage("SetMusicVolumne", MusicVolumne);
        soundControllerObject.SendMessage("SetSFXVolumne", SFXVolumne);

    }

    // Update is called once per frame
    void Update()
    {
        //Add to the timer
        timer += Time.deltaTime;

        if(timer > 15f)
        {
            GameManager.Singleton.MainMenu();
        }
        else if(timer > 12f)
        {
            colour.a += (FadeRate * 2.0f * Time.deltaTime);
            BlackScreen.color = colour;
        }

        else if(timer > 8f)
        {
            ShowGameNameImage(true);
            if(playSFXOnce)
            {
                soundControllerObject.SendMessage("PlayEffects", sfxIndex);
                playSFXOnce = false;
            }
        }
        else if(timer > 6f)
        {
            colour.a -= (FadeRate * 2.0f * Time.deltaTime);
            BlackScreen.color = colour;

            if(BackgroundNameImage.activeSelf == false)
            {
                ShowGameBackgroundImage(true);
                ShowBVGLogoImage(false);
            }
        }
        else if(timer > 3f)
        {
            colour.a += (FadeRate * Time.deltaTime);
            BlackScreen.color = colour;
        }   
        else if (timer > 0f)
        {
            colour.a -= (FadeRate * Time.deltaTime);
            BlackScreen.color = colour;
        }
    }


    void ShowGameBackgroundImage(bool show)
    {
        BackgroundNameImage.SetActive(show);
    }
    void ShowBVGLogoImage(bool show)
    {
        BVGLogoImage.SetActive(show);
    }
    void ShowGameNameImage(bool show)
    {
        GameNameImage.SetActive(show);
    }
}
