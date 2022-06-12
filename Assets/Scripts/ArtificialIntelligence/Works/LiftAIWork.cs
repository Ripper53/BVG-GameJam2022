using ArtificialIntelligence.Dependency;
using Physics.GetColliders;
using UnityEngine;

namespace ArtificialIntelligence {
    public class LiftAIWork : AIWork {
        public GetCollider LiftGetCollider;
        public float GripStrength;
        public GetCollider OpenGetCollider;

        protected new Rigidbody2D rigidbody;
        protected AbilityDependency abilityDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out abilityDependency) && TryGetComponent(out rigidbody);
        }

        private TargetJoint2D equipped = null;
        protected override void Execute() {
            if (abilityDependency.GetHold() && (equipped || PickUp())) {
                // Picked/Picking Up
                equipped.target = rigidbody.position;
            } else if (equipped) {
                Destroy(equipped);
                equipped = null;
            } else if (abilityDependency.GetTrigger() && OpenGetCollider.Get(out Collider2D collider) && collider.TryGetComponent(out IOpenable openable)) {
                openable.Open();
            }
        }

        private bool PickUp() {
            if (LiftGetCollider.Get(out Collider2D collider) && collider.attachedRigidbody && collider.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic) {
                equipped = collider.gameObject.AddComponent<TargetJoint2D>();
                Vector2 diff = rigidbody.position - collider.attachedRigidbody.position;
                equipped.anchor = diff + (diff.normalized * 0.1f);
                equipped.frequency = GripStrength;
                equipped.dampingRatio = 1f;
                return true;
            }
            return false;
        }

        protected void OnDisable() {
            if (equipped) {
                Destroy(equipped);
                equipped = null;
            }
        }

    }
}
