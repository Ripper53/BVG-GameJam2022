using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameMusicController : MonoBehaviour
{

    private GameObject soundControllerObject;

    [Range(0.0f, 1.0f)]
    public float MusicVolume = 0.2f;


    public int MusicIndex = 2;


    // Start is called before the first frame update
    void Start()
    {
        soundControllerObject = GameObject.Find("SoundController"); 
        soundControllerObject.SendMessage("SetMusicVolumne", MusicVolume);
        soundControllerObject.SendMessage("PlayMusic", MusicIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
