using UnityEngine;

public class PirateSoundController : CharacterSoundController {
    public RandomAudioClip PirateIdleSFX;
    public RandomAudioClip PirateAngrySFX;
    public RandomAudioClip PirateFriendlySFX;

    private bool IsFriendly => false;

    protected override AudioClip GetIdleSFX() {
        return IsFriendly ? PlayHappyFriendlySFX() : PirateIdleSFX.Get();
    }

    protected override AudioClip GetAngrySFX() {
        return PirateAngrySFX.Get();
    }

    private AudioClip PlayHappyFriendlySFX() {
        return PirateFriendlySFX.Get();
    }

}
