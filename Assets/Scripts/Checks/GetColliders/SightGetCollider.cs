using UnityEngine;

namespace Physics.GetColliders {
    public class SightGetCollider : RayGetCollider {

        protected override bool Cast(Collider2D col) {
            return InView(col) && base.Cast(col);
        }

        private bool InView(Collider2D col) {
            float target = col.transform.position.x, origin = Origin.position.x;
            float diff = target - origin;
            return SpriteRenderer.flipX ? diff < 0.1f : diff > -0.1f;
        }

    }
}
