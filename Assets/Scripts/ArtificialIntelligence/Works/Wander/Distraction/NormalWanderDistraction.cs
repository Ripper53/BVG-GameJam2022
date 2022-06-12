using UnityEngine;

namespace ArtificialIntelligence {
    public class NormalWanderDistraction : WanderDistraction {

        public override Vector2 GetDistraction(Vector2 position) {
            return position;
        }

    }
}
