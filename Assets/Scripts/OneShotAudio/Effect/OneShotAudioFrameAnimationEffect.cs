using SpriteAnimation;

namespace Audio {
    public class OneShotAudioFrameAnimationEffect : OneShotAudioEffect {
        public FrameAnimator Animator;
        public SpriteAnimation.SpriteAnimation Animation;

        protected void OnEnable() {
            Animator.SetAnimation(Animation);
        }

        protected void Update() {
            if (Animator.IsFinished)
                Deactivate();
        }

    }
}
