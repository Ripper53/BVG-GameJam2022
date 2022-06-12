using System.Collections.Generic;
using UnityEngine;

namespace Physics.GetColliders {
    public class SightGetCollider : GetCollider {
        public Transform Origin;
        public GetCollider GetCollider;
        public LayerMask BlockFilter;

        public override bool Get(out Collider2D collider) {
            return GetCollider.Get(out collider) && Cast(collider);
        }

        public override IEnumerable<Collider2D> Get() {
            foreach (Collider2D col in GetCollider.Get()) {
                if (Cast(col))
                    yield return col;
            }
        }

        private bool Cast(Collider2D col) {
            return !Physics2D.Raycast(Origin.position, col.transform.position - Origin.position, Vector2.Distance(col.transform.position, Origin.position), BlockFilter).collider;
        }

    }
}
