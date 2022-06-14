using SpriteAnimation;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    public Character Character;
    public SpriteRenderer SpriteRenderer;
    public FrameAnimator Animator;

    public SpriteAnimation.SpriteAnimation IdleAnimation, WalkAnimation;

    protected void Awake() {
        Character.HorizontalDirectionChanged += Character_HorizontalDirectionChanged;
    }

    protected void OnDestroy() {
        Character.HorizontalDirectionChanged -= Character_HorizontalDirectionChanged;
    }

    protected void OnEnable() {
        SetAnimation();
    }

    private void Character_HorizontalDirectionChanged(Character.HorizontalMovementDirection direction) {
        if (!enabled) return;
        SetAnimation();
    }

    private void SetAnimation() {
        switch (Character.HorizontalDirection) {
            case Character.HorizontalMovementDirection.Right:
                SpriteRenderer.flipX = false;
                Animator.SetAnimation(WalkAnimation);
                break;
            case Character.HorizontalMovementDirection.Left:
                SpriteRenderer.flipX = true;
                Animator.SetAnimation(WalkAnimation);
                break;
            default:
                Animator.SetAnimation(IdleAnimation);
                break;
        }
    }

}
