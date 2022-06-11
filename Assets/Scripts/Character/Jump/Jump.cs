using UnityEngine;

namespace Jump {
    public class Jump : MonoBehaviour {
        public Character Character;
        public Vector2 Force;

        public bool Execute() {
            if (Character.GroundCheck.Evaluate()) {
                Character.GroundCheck.DisableFor(0.1f);
                Character.Movement.Velocity = new Vector2(Direction * Force.x, Force.y);
                return true;
            }
            return false;
        }
        private float Direction {
            get {
                return Character.HorizontalDirection switch {
                    Character.HorizontalMovementDirection.Right => 1f,
                    Character.HorizontalMovementDirection.Left => -1f,
                    _ => 0f,
                };
            }
        }

    }
}
