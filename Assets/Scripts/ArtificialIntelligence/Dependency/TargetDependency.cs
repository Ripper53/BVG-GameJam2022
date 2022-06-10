using UnityEngine;

namespace ArtificialIntelligence.Dependency {
    public abstract class TargetDependency : MonoBehaviour {
        /// <summary>
        /// Gets target if available.
        /// </summary>
        /// <returns>True if a target was found, otherwise false.</returns>
        public abstract bool Get(out Vector2 target);
    }
}
