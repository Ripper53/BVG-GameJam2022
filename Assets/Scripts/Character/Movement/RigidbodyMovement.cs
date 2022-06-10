using UnityEngine;

namespace Movement {
    public class RigidbodyMovement : Movement {
        public Rigidbody2D Rigidbody;

        protected override void ExecuteMovement(Vector2 amount) {
            Rigidbody.velocity = amount / Time.fixedDeltaTime;
        }

    }
}
