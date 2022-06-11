using ArtificialIntelligence.Dependency;
using UnityEngine;

namespace ArtificialIntelligence {
    public class FlyingAIWork : AIWork {
        public float Speed;

        protected TargetDependency target;
        protected GroundFriction friction;
        protected new Rigidbody2D rigidbody;

        protected override bool GetDependencies() {
            return TryGetComponent(out target) && TryGetComponent(out friction) && TryGetComponent(out rigidbody);
        }

        private bool isFlying;
        protected void OnEnable() {
            isFlying = false;
        }

        protected void OnDisable() {
            if (isFlying) {
                isFlying = false;
                EnableGroundMovement(true);
            }
        }

        protected override void Execute() {
            if (target.Get(out Vector2 t)) {
                if (!isFlying) {
                    isFlying = true;
                    EnableGroundMovement(false);
                }
                Vector2 dir = t - rigidbody.position;
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
            } else if (isFlying) {
                isFlying = false;
                EnableGroundMovement(true);
            }
        }

        private void EnableGroundMovement(bool value) {
            friction.enabled = value;
            if (value) {
                rigidbody.gravityScale = 1f;
            } else {
                rigidbody.gravityScale = 0f;
                rigidbody.drag = 0f;
            }
        }

    }
}
