using Audio.Pooler;
using UnityEngine;
using Utility.Pooling;

namespace Audio {
    public class OneShotAudioEffect : ObjectPoolable<OneShotAudioEffect> {
        public AudioClip Clip;
        public float Volume = 1f;
        public OneShotAudioPooler AudioPooler;

        public void Set(Vector2 position) {
            transform.position = position;
            gameObject.SetActive(true);
            if (AudioPooler.Get(out OneShotAudio audio))
                audio.Set(position, Clip, Volume);
        }

        protected void Deactivate() {
            this.AddToPool();
        }

    }
}
