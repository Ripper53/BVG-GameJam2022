using UnityEngine;

namespace Movement {
    public abstract class Movement : MonoBehaviour {
        private Vector2 toMove = Vector2.zero;
        private bool toMoveThisFrame = false;

        protected void OnDisable() {
            toMove = Vector2.zero;
            toMoveThisFrame = false;
        }

        public void Move(Vector2 amount) {
            toMove += amount;
            toMoveThisFrame = true;
        }

        internal void ExecuteMovement() {
            if (!toMoveThisFrame) return;
            toMoveThisFrame = false;
            ExecuteMovement(toMove);
            toMove = Vector2.zero;
        }
        protected abstract void ExecuteMovement(Vector2 amount);

    }
}
