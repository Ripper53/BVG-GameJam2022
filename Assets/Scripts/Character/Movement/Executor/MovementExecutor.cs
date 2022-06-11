using UnityEngine;

namespace Movement {
    public class MovementExecutor : MonoBehaviour {
        public Movement Movement;

        private bool active = true;
        /// <summary>
        /// Executes after default time.
        /// </summary>
        protected void FixedUpdate() {
            if (active)
                Movement.ExecuteMovement();
        }

        public void Activate() {
            active = true;
            Movement.Reinitialize();
        }

        public void Deactivate() {
            active = false;
        }

    }
}
