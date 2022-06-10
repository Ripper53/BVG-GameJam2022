using Physics.Shapes;
using UnityEngine;

namespace Physics.Checks {
    public class BoxCheck : Check {
        public BoxShape BoxShape;
        public LayerMask Filter;

        public override bool Evaluate() {
            return Physics2D.OverlapBox(BoxShape.Position, BoxShape.Size, BoxShape.Angle, Filter);
        }
    }

}
