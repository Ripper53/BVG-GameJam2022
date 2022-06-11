using UnityEngine;

namespace Movement {
    public class RigidbodyMovement : Movement {
        public Rigidbody2D Rigidbody;

        public override Vector2 Velocity {
            get => Rigidbody.velocity;
            set => Rigidbody.velocity = value;
        }

        protected override void ExecuteMovement(float amount) {
            Rigidbody.velocity = new Vector2(amount / Time.fixedDeltaTime, Rigidbody.velocity.y * 0.25f);
        }

    }
}
