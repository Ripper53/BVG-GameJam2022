using UnityEngine;

namespace Movement {
    public abstract class Movement : MonoBehaviour {
        private float toMove = 0f;
        private bool toMoveThisFrame = false;

        public abstract Vector2 Velocity { get; set; }

        protected void OnDisable() {
            toMove = 0f;
            toMoveThisFrame = false;
        }

        public void Move(float amount) {
            toMove += amount;
            toMoveThisFrame = true;
        }

        internal void ExecuteMovement() {
            if (!toMoveThisFrame) return;
            toMoveThisFrame = false;
            ExecuteMovement(toMove);
            toMove = 0f;
        }
        protected abstract void ExecuteMovement(float amount);

    }
}
