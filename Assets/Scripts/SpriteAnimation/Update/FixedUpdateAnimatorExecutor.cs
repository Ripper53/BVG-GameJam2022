using UnityEngine;

namespace SpriteAnimation {
    public class FixedUpdateAnimatorExecutor : MonoBehaviour {
        public FrameAnimator Animator;

        protected void FixedUpdate() {
            Animator.Execute(Time.fixedDeltaTime);
        }

    }
}
