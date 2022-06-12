using UnityEngine;

namespace Movement {
    public abstract class Movement : MonoBehaviour {
        private float toMoveAmount = 0f;
        private bool toMoveThisFrame = false;

        public abstract Vector2 Velocity { get; set; }

        public void Move(float amount) {
            toMoveAmount += amount;
            toMoveThisFrame = true;
        }

        internal void ExecuteMovement() {
            if (!toMoveThisFrame) return;
            ExecuteMovement(toMoveAmount);
            Reinitialize();
        }
        protected abstract void ExecuteMovement(float amount);

        public void Reinitialize() {
            toMoveAmount = 0f;
            toMoveThisFrame = false;
        }

    }
}
