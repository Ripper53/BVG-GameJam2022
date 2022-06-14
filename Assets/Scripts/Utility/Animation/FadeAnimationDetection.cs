using UnityEngine;

public class FadeAnimationDetection : AnimationDetection {
    public SpriteRenderer SpriteRenderer;
    public float Time;

    protected void OnEnable() {
        target = SpriteRenderer.color.a;
    }

    protected override void ActivateAnimation() {
        target = 0.5f;
    }

    protected override void DeactivateAnimation() {
        target = 1f;
    }

    private float target, vel;

    protected void Update() {
        Color color = SpriteRenderer.color;
        color.a = Mathf.SmoothDamp(color.a, target, ref vel, Time);
        SpriteRenderer.color = color;
    }

}
