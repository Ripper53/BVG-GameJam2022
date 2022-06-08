using UnityEngine;

namespace SpriteAnimation {
    public abstract class FrameAnimator : MonoBehaviour {
        public SpriteAnimation CurrentAnimation { get; private set; }
        private SpriteAnimation.Frame CurrentFrame => CurrentAnimation.Frames[index];

        public bool IsFinished => !CurrentAnimation || (!CurrentAnimation.Loop && index == CurrentAnimation.Frames.Length && duration <= 0f);

        private int index;
        private float duration;

        public void SetAnimation(SpriteAnimation animation) {
            index = 0;
            CurrentAnimation = animation;
            duration = CurrentFrame.Duration;
            SetSprite(CurrentFrame.Sprite);
        }
        protected abstract void SetSprite(Sprite sprite);

        public void Execute(float deltaTime) {
            if (IsFinished) return;
            duration -= deltaTime;
            if (duration <= 0f) {
                index += 1;
                if (index < CurrentAnimation.Frames.Length) {
                    SetFrame(CurrentFrame);
                } else if (CurrentAnimation.Loop) {
                    index = 0;
                    SetFrame(CurrentFrame);
                }
            }
        }
        private void SetFrame(SpriteAnimation.Frame frame) {
            duration += frame.Duration;
            SetSprite(frame.Sprite);
        }

    }
}
