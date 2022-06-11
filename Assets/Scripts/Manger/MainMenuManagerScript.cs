using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManagerScript : MonoBehaviour
{

    //Sounds
    private GameObject soundControllerObject;

    public int MainMenuSongIndex = 1;
    public int MainMenuPirateSFXIndex = 1;

    public int OnHoverStartSFXIndex = 2;
    public int OnHoverQuitSFXIndex = 3;

    // Start is called before the first frame update
    void Start()
    {

        soundControllerObject = GameObject.Find("SoundController");

        soundControllerObject.SendMessage("PlayMusic", MainMenuSongIndex);

        soundControllerObject.SendMessage("PlayEffects", MainMenuPirateSFXIndex);

    }


    public void OnHoverStartSFX()
    {
        soundControllerObject.SendMessage("PlayEffects", OnHoverStartSFXIndex);
    }

    public void OnHoverQuitSFX()
    {
        soundControllerObject.SendMessage("PlayEffects", OnHoverQuitSFXIndex);
    }
}
