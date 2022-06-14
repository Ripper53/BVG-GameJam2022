using UnityEngine;

public class MainGameMusicController : MonoBehaviour
{
    public SoundController SoundController;

    [Range(0.0f, 1.0f)]
    public float MusicVolume = 0.2f;


    public int MusicIndex = 2;


    void Start()
    {
        SoundController.MusicVolume = MusicVolume;
        SoundController.PlayMusic(MusicIndex);
    }

}
