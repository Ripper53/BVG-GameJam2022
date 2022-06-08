using UnityEngine;

namespace SpriteAnimation {
    public class UpdateAnimatorExecutor : MonoBehaviour {
        public FrameAnimator Animator;

        protected void Update() {
            Animator.Execute(Time.deltaTime);
        }

    }
}
