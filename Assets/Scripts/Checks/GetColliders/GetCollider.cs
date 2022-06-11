using System.Collections.Generic;
using UnityEngine;

namespace Physics.GetColliders {
    public abstract class GetCollider : MonoBehaviour {
        /// <summary>
        /// Get a single collider detected.
        /// </summary>
        /// <returns>Get a single detected collider.</returns>
        public abstract bool Get(out Collider2D collider);
        /// <summary>
        /// Get all colliders detected.
        /// </summary>
        /// <returns>All detected colliders.</returns>
        public abstract IEnumerable<Collider2D> Get();
    }
}
