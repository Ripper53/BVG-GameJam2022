using SpriteAnimation;
using UnityEngine;

public class OpenableAnimator : MonoBehaviour {
    public Openable Openable;
    public FrameAnimator Animator;
    public SpriteAnimation.SpriteAnimation OpenAnimation;

    protected void Awake() {
        Openable.Opened += Openable_Opened;
    }

    private void Openable_Opened(Openable source) {
        Animator.SetAnimation(OpenAnimation);
    }

}
