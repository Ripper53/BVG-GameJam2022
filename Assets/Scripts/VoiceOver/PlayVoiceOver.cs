using UnityEngine;

public class PlayVoiceOver : MonoBehaviour {
    public VoiceOverData VoiceOverData;
    public AudioSource AudioSource;

    public void Play(AudioClip clip) {
        AudioSource.clip = clip;
        AudioSource.Play();
        enabled = true;
    }

    protected void OnEnable() {
        VoiceOverData.Speaking += 1;
    }

    protected void Update() {
        if (!AudioSource.isPlaying) {
            VoiceOverData.Speaking--;
            enabled = false;
        }
    }

}
