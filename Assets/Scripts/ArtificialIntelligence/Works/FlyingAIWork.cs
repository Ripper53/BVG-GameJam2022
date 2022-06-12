using ArtificialIntelligence.Dependency;
using UnityEngine;

namespace ArtificialIntelligence {
    public class FlyingAIWork : InAirAIWork {
        public float Speed;
        public SpriteRenderer SpriteRenderer;

        protected TargetDependency targetDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out targetDependency) && base.GetDependencies();
        }

        protected override bool GetTarget(out Vector2 target) {
            return targetDependency.Get(out target);
        }

        protected override void ExecuteFlight(Vector2 target) {
            Vector2 dir = target - rigidbody.position;
            SpriteRenderer.flipX = dir.x < 0f;
            const float distance = 1f, sqrDistance = distance * distance;
            float currentDistance = dir.sqrMagnitude;
            if (currentDistance < sqrDistance) {
                float speed = currentDistance / sqrDistance;
                if (speed < 0.1f)
                    character.Movement.Velocity = Vector2.zero;
                else
                    character.Movement.Velocity = Speed * speed * dir.normalized;
            } else {
                character.Movement.Velocity = Speed * dir.normalized;
            }
        }

    }
}
