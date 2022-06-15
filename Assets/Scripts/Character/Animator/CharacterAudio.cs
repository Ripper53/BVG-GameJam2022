using ArtificialIntelligence;
using UnityEngine;

public class CharacterAudio : MonoBehaviour {
    public Character Character;
    public GroundCheck GroundCheck;
    public AudioSource WalkAudioSource, FlyAudioSource;
    public FlyingAIWork FlyingAIWork;

    protected void Update() {
        if (WalkAudioSource.isPlaying) {
            if (Character.HorizontalDirection == Character.HorizontalMovementDirection.None || FlyingAIWork.InAir || !GroundCheck.Evaluate())
                WalkAudioSource.Stop();
        } else if (Character.HorizontalDirection != Character.HorizontalMovementDirection.None && GroundCheck.Evaluate()) {
            WalkAudioSource.Play();
        }

        if (FlyingAIWork.InAir) {
            if (!FlyAudioSource.isPlaying)
                FlyAudioSource.Play();
        } else if (FlyAudioSource.isPlaying) {
            FlyAudioSource.Stop();
        }
    }

}
