using ArtificialIntelligence;
using UnityEngine;

public class CharacterAudio : MonoBehaviour {
    public Character Character;
    public GroundCheck GroundCheck;
    public AudioSource AudioSource;
    public FlyingAIWork FlyingAIWork;

    protected void Update() {
        if (AudioSource.isPlaying) {
            if (Character.HorizontalDirection == Character.HorizontalMovementDirection.None || FlyingAIWork.InAir || !GroundCheck.Evaluate())
                AudioSource.Stop();
        } else if (Character.HorizontalDirection != Character.HorizontalMovementDirection.None && GroundCheck.Evaluate()) {
            AudioSource.Play();
        }
    }

}
