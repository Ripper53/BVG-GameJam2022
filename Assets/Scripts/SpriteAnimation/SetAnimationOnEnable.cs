using UnityEngine;

namespace SpriteAnimation.Utility {
    public class SetAnimationOnEnable : MonoBehaviour {
        public FrameAnimator Animator;
        public SpriteAnimation Animation;

        protected void OnEnable() {
            Animator.SetAnimation(Animation);
        }

    }
}
