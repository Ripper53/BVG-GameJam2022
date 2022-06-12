using UnityEngine;

namespace ArtificialIntelligence {
    public class JumpAttack : MonoBehaviour {
        public Jump.Jump Jump;
        public AttackAIWork Attack;
        public SpriteRenderer SpriteRenderer;
        public Vector2 Force;

        protected void Awake() {
            Attack.Attacking += Attack_Attacking;
        }

        private void Attack_Attacking(AttackAIWork source) {
            float dir = SpriteRenderer.flipX ? -1f : 1f;
            Jump.Execute(Force, dir);
        }

    }
}
