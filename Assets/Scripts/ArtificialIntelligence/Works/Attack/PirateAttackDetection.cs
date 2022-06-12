using UnityEngine;

namespace ArtificialIntelligence {
    public class PirateAttackDetection : AttackDetection {
        public string FriendlyTag;

        public override bool Detect() {
            SetOffset(DetectData.BoxShape);
            return DetectData.GetCollider.Get(out Collider2D collider) && !collider.CompareTag(FriendlyTag);
        }

    }
}
