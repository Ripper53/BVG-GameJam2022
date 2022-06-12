using SpriteAnimation;
using UnityEngine;

namespace ArtificialIntelligence {
    public class AttackAIWork : MonoBehaviour {
        public SpriteAnimator Animator;
        public AttackDetection Detection;
        public AttackExecutor Executor;

        public bool IsFinished { get; set; } = false;

        public delegate void AttackAction(AttackAIWork source);
        public event AttackAction Attacking;
        public void Attack() {
            Executor.enabled = true;
            IsFinished = false;
            Attacking?.Invoke(this);
        }

    }
}
