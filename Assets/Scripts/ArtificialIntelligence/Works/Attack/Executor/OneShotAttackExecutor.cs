using SpriteAnimation;

namespace ArtificialIntelligence {
    public class OneShotAttackExecutor : AttackExecutor {
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
            if (Animator.IsFinished) {
                switch (currentState) {
                    case State.Attacking:
                        if (Attack.Detection.Attack()) {
                            // Game Over
                            //GameManager.Singleton.LoseGame();
                        }
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
