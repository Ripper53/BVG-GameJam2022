using Physics.GetColliders;
using Physics.Shapes;
using SpriteAnimation;
using UnityEngine;

namespace ArtificialIntelligence {
    public class AttackDetection : MonoBehaviour {
        public SpriteAnimator Animator;
        public Data DetectData, AttackData;
        [System.Serializable]
        public struct Data {
            public BoxGetCollider GetCollider;
            public BoxShape BoxShape;
        }

        public virtual bool Detect() {
            SetOffset(DetectData.BoxShape);
            return DetectData.GetCollider.Get(out _);
        }

        public bool Attack(out Collider2D collider) {
            SetOffset(AttackData.BoxShape);
            return AttackData.GetCollider.Get(out collider);
        }

        protected void SetOffset(BoxShape boxShape) {
            Vector2 offset = boxShape.Offset;
            offset.x = Animator.SpriteRenderer.flipX ? -Mathf.Abs(offset.x) : Mathf.Abs(offset.x);
            boxShape.Offset = offset;
        }

    }
}
