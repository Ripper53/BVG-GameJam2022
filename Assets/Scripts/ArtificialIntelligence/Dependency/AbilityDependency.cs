using UnityEngine;

namespace ArtificialIntelligence.Dependency {
    public abstract class AbilityDependency : MonoBehaviour {
        public abstract bool GetTrigger();
        public abstract bool GetHold();
        public abstract bool GetTarget(out Vector2 target);
    }
}
