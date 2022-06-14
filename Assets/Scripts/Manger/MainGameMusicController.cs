using UnityEngine;

public class MainGameMusicController : MonoBehaviour
{
    private GameObject SoundControllerObj;

    [Range(0.0f, 1.0f)]
    public float MusicVolume = 0.2f;


    public int MusicIndex = 2;


    void Start()
    {
        SoundControllerObj = GameObject.Find("SoundController");
        SoundControllerObj.SendMessage("SetMusicVolumne", MusicVolume);
        SoundControllerObj.SendMessage("PlayMusic", MusicIndex);
    }

}
