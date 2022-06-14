using UnityEngine;
using Utility.Pooling;

namespace Audio {
    public class OneShotAudio : ObjectPoolable<OneShotAudio> {
        public AudioSource AudioSource;

        public void Set(Vector2 position, AudioClip clip, float volume) {
            transform.position = position;
            AudioSource.clip = clip;
            AudioSource.volume = volume;
            gameObject.SetActive(true);
        }

        protected void OnEnable() {
            AudioSource.Play();
        }

        protected void Update() {
            if (!AudioSource.isPlaying)
                this.AddToPool();
        }

    }
}
