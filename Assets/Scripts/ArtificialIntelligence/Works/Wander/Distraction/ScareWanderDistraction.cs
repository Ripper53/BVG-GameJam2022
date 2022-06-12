using UnityEngine;

namespace ArtificialIntelligence {
    public class ScareWanderDistraction : WanderDistraction {
        public Rigidbody2D Rigidbody;
        public float Distance;

        public override Vector2 GetDistraction(Vector2 position) {
            return new Vector2((position.x - Rigidbody.position.x) > 0f ? -Distance : Distance, 0f) + Rigidbody.position;
        }

    }
}
