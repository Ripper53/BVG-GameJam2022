using Physics.Shapes;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.GetColliders {
    public class BoxGetCollider : GetCollider {
        public BoxShape BoxShape;
        public LayerMask Filter;

        public override bool Get(out Collider2D collider) {
            collider = Physics2D.OverlapBox(BoxShape.Position, BoxShape.Size, BoxShape.Angle, Filter);
            if (collider)
                return true;
            return false;
        }

        private readonly List<Collider2D> cols = new(); // Cached colliders!
        public override IEnumerable<Collider2D> Get() {
            cols.Clear();
            Physics2D.OverlapBox(BoxShape.Position, BoxShape.Size, BoxShape.Angle, new ContactFilter2D { useLayerMask = true, layerMask = Filter }, cols);
            return cols;
        }

    }
}
