using Physics.GetColliders;
using Physics.Shapes;
using SpriteAnimation;
using UnityEngine;

namespace ArtificialIntelligence {
    public class AttackAIWork : MonoBehaviour {
        public SpriteAnimator Animator;
        public BoxGetCollider GetCollider;
        public BoxShape BoxShape;
        public SpriteAnimation.SpriteAnimation Animation, RecoveryAnimation, IdleAnimation;

        public bool IsFinished { get; private set; } = false;

        public bool Detection() {
            SetOffset();
            return GetCollider.Get(out _);
        }

        private State currentState;
        private enum State {
            Attacking, Recovery
        }

        public void Attack() {
            Animator.SetAnimation(Animation);
            enabled = true;
            IsFinished = false;
            currentState = State.Attacking;
        }

        private void SetOffset() {
            Vector2 offset = BoxShape.Offset;
            offset.x = Animator.SpriteRenderer.flipX ? -Mathf.Abs(offset.x) : Mathf.Abs(offset.x);
            BoxShape.Offset = offset;
        }

        protected void FixedUpdate() {
            if (Animator.IsFinished) {
                switch (currentState) {
                    case State.Attacking:
                        SetOffset();
                        if (GetCollider.Get(out _)) {
                            // Game Over
                        }
                        Animator.SetAnimation(RecoveryAnimation);
                        currentState = State.Recovery;
                        break;
                    default:
                        Animator.SetAnimation(IdleAnimation);
                        IsFinished = true;
                        enabled = false;
                        break;
                }
            }
        }

    }
}
