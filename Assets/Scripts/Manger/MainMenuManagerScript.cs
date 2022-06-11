using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{

    //Sounds
    private GameObject soundControllerObject;

    private int songIndex = 1;
    private int sfxIndex = 1;

    // Start is called before the first frame update
    void Start()
    {

        soundControllerObject = GameObject.Find("SoundController");

        soundControllerObject.SendMessage("PlayMusic", songIndex);

        soundControllerObject.SendMessage("PlayEffects", sfxIndex);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
