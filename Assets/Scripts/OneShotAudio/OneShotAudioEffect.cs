using Audio.Pooler;
using SpriteAnimation;
using UnityEngine;
using Utility.Pooling;

namespace Audio {
    public class OneShotAudioEffect : ObjectPoolable<OneShotAudioEffect> {
        public FrameAnimator Animator;
        public SpriteAnimation.SpriteAnimation Animation;
        public AudioClip Clip;
        public OneShotAudioPooler AudioPooler;

        public void Set(Vector2 position) {
            transform.position = position;
            gameObject.SetActive(true);
            if (AudioPooler.Get(out OneShotAudio audio))
                audio.Set(position, Clip);
        }

        protected void OnEnable() {
            Animator.SetAnimation(Animation);
        }

        protected void Update() {
            if (Animator.IsFinished)
                this.AddToPool();
        }

    }
}
