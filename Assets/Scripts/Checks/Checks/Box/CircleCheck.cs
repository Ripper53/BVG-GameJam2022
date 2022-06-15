using Physics.Shapes;
using UnityEngine;

namespace Physics.Checks {
    public class CircleCheck : Check {
        public CircleShape CircleShape;
        public LayerMask Filter;

        public override bool Evaluate() {
            return Physics2D.OverlapCircle(CircleShape.Position, CircleShape.Radius, Filter);
        }
    }

}
