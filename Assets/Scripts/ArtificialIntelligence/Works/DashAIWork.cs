using ArtificialIntelligence.Dependency;
using Audio;
using Audio.Pooler;
using UnityEngine;
using Utility.Pooling;

namespace ArtificialIntelligence {
    public class DashAIWork : InAirAIWork {
        public float Speed;
        public float Duration;
        public OneShotAudioEffectPooler EffectPooler;

        protected FlyingAIWork flying;
        protected AbilityDependency abilityDependency;

        private float dashTimer;

        protected override bool GetDependencies() {
            return TryGetComponent(out flying) && TryGetComponent(out abilityDependency) && base.GetDependencies();
        }

        private Vector2 latestTarget;
        protected override bool GetTarget(out Vector2 target) {
            if (dashTimer > 0f) {
                target = latestTarget;
                return true;
            } else if (abilityDependency.GetTarget(out latestTarget)) {
                latestTarget -= rigidbody.position;
                target = latestTarget;
                return true;
            }
            target = default;
            return false;
        }

        protected override void ExecuteFlight(Vector2 target) {
            dashTimer -= Time.fixedDeltaTime;
            character.Movement.Velocity = Speed * target.normalized;
        }

        protected override void EnableGroundMovement(bool value) {
            base.EnableGroundMovement(value);
            flying.enabled = value;
            if (!value) {
                dashTimer = Duration;
                if (EffectPooler.Get(out OneShotAudioEffect effect))
                    effect.Set(rigidbody.position);
            }
        }

    }
}
