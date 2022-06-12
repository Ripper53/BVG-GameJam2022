using SpriteAnimation;
using UnityEngine;

namespace ArtificialIntelligence {
    public class DetectionAttackExecutor : AttackExecutor {
        public SpriteAnimator Animator;
        public SpriteAnimation.SpriteAnimation Animation, RecoveryAnimation, IdleAnimation;

        private State currentState;
        private enum State {
            Attacking, Recovery
        }

        protected void OnEnable() {
            currentState = State.Attacking;
            Animator.SetAnimation(Animation);
        }

        protected void OnDisable() {
            Animator.SetAnimation(IdleAnimation);
            Attack.IsFinished = true;
        }

        protected void FixedUpdate() {
            if (Attack.Detection.Attack(out Collider2D collider) && collider.TryGetComponent(out EndGameMenu menu)) {
                Animator.SetAnimation(RecoveryAnimation);
                // Game Over
                menu.LoseGame();
                enabled = false;
            } else if (Animator.IsFinished) {
                switch (currentState) {
                    case State.Attacking:
                        Animator.SetAnimation(RecoveryAnimation);
                        currentState = State.Recovery;
                        break;
                    default:
                        enabled = false;
                        break;
                }
            }
        }

    }
}
