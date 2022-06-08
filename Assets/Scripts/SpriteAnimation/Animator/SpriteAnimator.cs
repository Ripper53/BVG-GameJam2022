using UnityEngine;

namespace SpriteAnimation {
    public class SpriteAnimator : FrameAnimator {
        public SpriteRenderer SpriteRenderer;

        protected override void SetSprite(Sprite sprite) {
            SpriteRenderer.sprite = sprite;
        }

    }
}
