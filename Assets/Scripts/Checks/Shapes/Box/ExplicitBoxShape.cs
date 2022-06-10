using UnityEngine;

namespace Physics.Shapes {
    public class ExplicitBoxShape : BoxShape {
        public Transform Origin;
        [SerializeField]
        private Vector2 offset, size;
        [SerializeField]
        private float angle;

        public override Vector2 Offset {
            get => offset;
            set => offset = value;
        }
        public override Vector2 Size {
            get => size;
            set => size = value;
        }
        public override float Angle {
            get => angle;
            set => angle = value;
        }
        public override Vector2 Position => (Vector2)Origin.position + offset;

#if UNITY_EDITOR
        protected void OnDrawGizmosSelected() {
            if (!Origin) return;
            Gizmos.color = Color.green;
            Gizmos.matrix = Matrix4x4.TRS(Position, Quaternion.Euler(0f, 0f, Angle), Size);
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
#endif

    }
}
