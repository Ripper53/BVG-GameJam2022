using UnityEngine;

public class RatSoundController : CharacterSoundController {
    public RandomAudioClip IdleSFX;
    public RandomAudioClip AngrySFX;

    protected override AudioClip GetAngrySFX() {
        return AngrySFX.Get();
    }

    protected override AudioClip GetIdleSFX() {
        return IdleSFX.Get();
    }

}
