using ArtificialIntelligence.Dependency;
using Physics.GetColliders;
using UnityEngine;

namespace ArtificialIntelligence {
    public class TalkAIWork : AIWork {
        public GetCollider GetCollider;
        public string TalkTag;
        public RandomAudioClip AudioClip;
        public AudioSource AudioSource;

        protected new Rigidbody2D rigidbody;
        protected AbilityDependency abilityDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out rigidbody) && TryGetComponent(out abilityDependency);
        }

        protected override void Execute() {
            if (!AudioSource.isPlaying && abilityDependency.GetTrigger()) {
                foreach (Collider2D col in GetCollider.Get()) {
                    if (col.CompareTag(TalkTag)) {
                        if (col.TryGetComponent(out IDistract distract))
                            distract.Noise(rigidbody.position);
                        else if (col.TryGetComponent(out IPersuade persuade))
                            persuade.Persuade(rigidbody.position);
                    }
                }

                // Play audio!
                AudioSource.clip = AudioClip.Get();
                AudioSource.Play();
            }
        }

    }
}
