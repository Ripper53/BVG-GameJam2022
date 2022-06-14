using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "Random Audio Clip")]
public class RandomAudioClip : ScriptableObject {
    public AudioClip[] Clips;

    public AudioClip Get() {
        int index = Random.Range(0, Clips.Length - 1);
        AudioClip clip = Clips[index];
        AudioClip tempClip = Clips[^1];
        Clips[index] = tempClip;
        Clips[^1] = clip;
        return clip;
    }

}
