using SpriteAnimation;
using UnityEngine;

public class PirateOpensDoorScript : MonoBehaviour {
    public FrameAnimator Animator;
    public SpriteAnimation.SpriteAnimation DoorOpenAnimation;

    public GemTracker GemTracker;
    public Collider2D Collider;

    protected void Awake() {
        GemTracker.CollectedPowerGem += GemTracker_CollectedPowerGem;
    }

    private void GemTracker_CollectedPowerGem(GemTracker source, PowerGem gem) {
        if (gem.Colour != GemColour.Green) return;
        Collider.enabled = false;
        Animator.SetAnimation(DoorOpenAnimation);
    }

}
