using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class WanderDistraction : MonoBehaviour {
        public abstract Vector2 GetDistraction(Vector2 position);
    }
}
