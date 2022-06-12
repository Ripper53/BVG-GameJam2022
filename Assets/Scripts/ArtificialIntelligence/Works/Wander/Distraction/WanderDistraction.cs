using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class WanderDistraction : MonoBehaviour {
        public abstract Vector2 GetNoiseDistraction(Vector2 position);
        public abstract Vector2 GetFoodDistraction(Vector2 position);
    }
}
