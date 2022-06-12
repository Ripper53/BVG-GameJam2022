using UnityEngine;

namespace ArtificialIntelligence.Dependency {
    public class PlayerAbilityDependency : AbilityDependency {
        [System.NonSerialized]
        public bool Triggered, Hold;
        [System.NonSerialized]
        public Vector2 Target;

        public override bool GetTrigger() {
            return Triggered;
        }

        public override bool GetHold() {
            return Hold;
        }

        public override bool GetTarget(out Vector2 target) {
            target = Target;
            return Triggered;
        }

        /// <summary>
        /// Executes after default time!
        /// </summary>
        protected void FixedUpdate() {
            Triggered = false;
        }

    }
}
