using Physics.GetColliders;
using UnityEngine;

namespace ArtificialIntelligence {
    public class RatWanderJumpCondition : WanderJumpCondition {
        public WanderAIWork Wander;
        public GetCollider ChaseGetCollider;
        public string JumpTag;

        public override bool ShouldJump(GroundCheck groundCheck, SideCheck checks) {
            return Wander.CurrentState == WanderAIWork.State.Chase && ChaseGetCollider.Get(out Collider2D col) && col.CompareTag(JumpTag);
        }

    }
}
