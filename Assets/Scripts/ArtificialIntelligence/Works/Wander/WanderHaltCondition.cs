using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class WanderHaltCondition : MonoBehaviour {
        public abstract bool ShouldHalt(GroundCheck groundCheck, SideCheck checks);
    }
}
