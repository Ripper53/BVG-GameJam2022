using UnityEngine;

namespace Audio {
    public class OneShotAudioParticleEffect : OneShotAudioEffect {
        public ParticleSystem ParticleSystem;

        protected void OnEnable() {
            ParticleSystem.Play();
        }

        protected void Update() {
            if (!ParticleSystem.isPlaying)
                Deactivate();
        }

    }
}
