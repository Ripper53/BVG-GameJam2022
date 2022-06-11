using UnityEngine;

namespace Physics.Shapes {
    public class ExplicitCircleShape : CircleShape {
        public Transform Origin;
        [SerializeField]
        private float radius;
        public override float Radius {
            get => radius;
            set => radius = value;
        }
        public override Vector2 Position => Origin.position;

#if UNITY_EDITOR
        protected void OnDrawGizmosSelected() {
            if (!Origin) return;
            Gizmos.color = Color.green;
            Gizmos.matrix = Matrix4x4.TRS(Position, Quaternion.identity, Vector3.one);
            Gizmos.DrawWireSphere(Vector3.zero, radius);
        }
#endif

    }
}
