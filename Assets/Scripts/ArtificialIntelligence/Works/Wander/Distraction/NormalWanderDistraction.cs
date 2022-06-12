using UnityEngine;

namespace ArtificialIntelligence {
    public class NormalWanderDistraction : WanderDistraction {

        public override Vector2 GetNoiseDistraction(Vector2 position) {
            return position;
        }

        public override Vector2 GetFoodDistraction(Vector2 position) {
            return position;
        }

    }
}
