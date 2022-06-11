using Physics.Shapes;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.GetColliders {
    public class CircleGetCollider : GetCollider {
        public CircleShape CircleShape;
        public LayerMask Filter;

        public override bool Get(out Collider2D collider) {
            collider = Physics2D.OverlapCircle(CircleShape.Position, CircleShape.Radius, Filter);
            if (collider)
                return true;
            else
                return false;
        }

        private readonly List<Collider2D> colliders = new(); // Cache list of colliders!
        public override IEnumerable<Collider2D> Get() {
            colliders.Clear();
            Physics2D.OverlapCircle(CircleShape.Position, CircleShape.Radius, new ContactFilter2D { useLayerMask = true, layerMask = Filter }, colliders);
            return colliders;
        }

    }
}
