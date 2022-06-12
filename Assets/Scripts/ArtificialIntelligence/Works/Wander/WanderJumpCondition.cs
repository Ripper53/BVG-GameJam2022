using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class WanderJumpCondition : MonoBehaviour {
        public abstract bool ShouldJump(GroundCheck groundCheck, SideCheck checks);
    }
}
