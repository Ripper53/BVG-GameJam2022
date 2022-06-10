using UnityEngine;

namespace Movement {
    public class MovementExecutor : MonoBehaviour {
        public Movement Movement;

        /// <summary>
        /// Executes after default time.
        /// </summary>
        protected void FixedUpdate() {
            Movement.ExecuteMovement();
        }

    }
}
