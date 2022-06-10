using UnityEngine;

namespace Physics.Shapes {
    public abstract class BoxShape : Shape {
        public abstract Vector2 Offset { get; set; }
        public abstract Vector2 Size { get; set; }
        public abstract float Angle { get; set; }
    }
}
