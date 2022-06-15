using UnityEngine;

[CreateAssetMenu(fileName = "VoiceOverData", menuName = "Voice Over Data")]
public class VoiceOverData : ScriptableObject {
    [System.NonSerialized]
    public int Speaking;

    protected void Awake() {
        Speaking = 0;
    }

}
