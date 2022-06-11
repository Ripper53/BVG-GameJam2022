using Physics.GetColliders;
using UnityEngine;

namespace ArtificialIntelligence.Dependency {
    public class GetColliderTargetDependency : TargetDependency {
        public GetCollider GetCollider;

        public override bool Get(out Vector2 target) {
            if (GetCollider.Get(out Collider2D collider)) {
                target = collider.transform.position;
                return true;
            }
            target = default;
            return false;
        }

    }
}
