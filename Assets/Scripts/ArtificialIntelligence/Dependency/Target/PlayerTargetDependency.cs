using UnityEngine;

namespace ArtificialIntelligence.Dependency {
    public class PlayerTargetDependency : TargetDependency {
        [System.NonSerialized]
        public Vector2 Target;
        [System.NonSerialized]
        public bool Active = false;

        public override bool Get(out Vector2 target) {
            target = Target;
            return Active;
        }

    }
}
