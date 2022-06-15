using Physics.GetColliders;
using UnityEngine;

public class PirateSoundController : CharacterSoundController {
    public RandomAudioClip PirateIdleSFX;
    public RandomAudioClip PirateAngrySFX;
    public RandomAudioClip PirateFriendlySFX;

    public GetCollider SightGetCollider;
    public string FriendlyTag;

    private bool IsFriendly = false;

    protected override AudioClip GetIdleSFX() {
        return IsFriendly ? PlayHappyFriendlySFX() : PirateIdleSFX.Get();
    }

    protected override AudioClip GetAngrySFX() {
        return IsFriendly ? PlayHappyFriendlySFX() : PirateAngrySFX.Get();
    }

    private AudioClip PlayHappyFriendlySFX() {
        return PirateFriendlySFX.Get();
    }

    protected void FixedUpdate() {
        if (SightGetCollider.Get(out Collider2D collider))
            IsFriendly = collider.CompareTag(FriendlyTag);
    }

}
