using UnityEngine;
using Utility.Pooling;

namespace Audio {
    public class OneShotAudio : ObjectPoolable<OneShotAudio> {
        public AudioSource AudioSource;

        public void Set(Vector2 position, AudioClip clip) {
            transform.position = position;
            AudioSource.clip = clip;
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
