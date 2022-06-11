using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class InAirAIWork : AIWork {

        protected GroundFriction friction;
        protected new Rigidbody2D rigidbody;

        private bool inAir;

        protected override bool GetDependencies() {
            return TryGetComponent(out friction) && TryGetComponent(out rigidbody);
        }

        protected void OnEnable() {
            inAir = false;
        }

        protected void OnDisable() {
            if (inAir)
                EnableGroundMovement(true);
        }

        protected override void Execute() {
            if (GetTarget(out Vector2 target)) {
                if (!inAir) {
                    EnableGroundMovement(false);
                }
                ExecuteFlight(target);
            } else if (inAir) {
                EnableGroundMovement(true);
            }
        }
        protected abstract void ExecuteFlight(Vector2 target);
        protected abstract bool GetTarget(out Vector2 target);

        protected virtual void EnableGroundMovement(bool value) {
            inAir = !value;
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
