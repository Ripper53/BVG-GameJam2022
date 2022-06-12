using ArtificialIntelligence.Dependency;
using Physics.GetColliders;
using UnityEngine;

namespace ArtificialIntelligence {
    public class TalkAIWork : AIWork {
        public GetCollider GetCollider;
        public string TalkTag;

        protected new Rigidbody2D rigidbody;
        protected AbilityDependency abilityDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out rigidbody) && TryGetComponent(out abilityDependency);
        }

        protected override void Execute() {
            if (abilityDependency.GetTrigger()) {
                foreach (Collider2D col in GetCollider.Get()) {
                    if (col.CompareTag(TalkTag) && col.TryGetComponent(out IDistract distract))
                        distract.Noise(rigidbody.position);
                }
            }
        }

    }
}
