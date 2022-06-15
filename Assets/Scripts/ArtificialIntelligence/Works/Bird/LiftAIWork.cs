using ArtificialIntelligence.Dependency;
using Physics.GetColliders;
using System.Collections;
using UnityEngine;

namespace ArtificialIntelligence {
    public class LiftAIWork : AIWork {
        public GetCollider LiftGetCollider;
        public float GripStrength, GripOffset;
        public GetCollider OpenGetCollider;
        public FlyingAIWork Flying;

        public GroundFriction Friction;

        public AudioSource PickUpAudioSource;

        protected new Rigidbody2D rigidbody;
        protected AbilityDependency abilityDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out abilityDependency) && TryGetComponent(out rigidbody);
        }

        private Rigidbody2D equippedRigidbody = null;
        private TargetJoint2D equipped = null;
        //private float equippedMass;
        protected override void Execute() {
            if (abilityDependency.GetHold()) {
                // Picked/Picking Up
                if (equipped) {
                    equipped.target = rigidbody.position;
                } else {
                    PickUp();
                }
            } else if (equippedRigidbody) {
                Unequip();
            }

            // Open
            if (abilityDependency.GetTrigger()) {
                foreach (Collider2D col in OpenGetCollider.Get()) {
                    if (col.TryGetComponent(out IOpenable openable))
                        openable.Open();
                }
            }
        }

        private void PickUp() {
            if (coroutine == null && LiftGetCollider.Get(out Collider2D collider) && collider.attachedRigidbody && collider.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic) {
                Friction.enabled = false;
                rigidbody.drag = 0f;

                equippedRigidbody = collider.attachedRigidbody;
                //equippedMass = collider.attachedRigidbody.mass;
                equippedRigidbody.mass = 1f;

                coroutine = StartCoroutine(PickUp(collider));
            }
        }

        private Coroutine coroutine = null;
        private IEnumerator PickUp(Collider2D collider) {
            yield return new WaitForFixedUpdate();
            equipped = collider.gameObject.AddComponent<TargetJoint2D>();
            equipped.anchor = equipped.transform.InverseTransformPoint(rigidbody.position);
            equipped.frequency = GripStrength;
            equipped.dampingRatio = 1f;

            PickUpAudioSource.Play();

            coroutine = null;
        }

        protected void OnDisable() {
            if (coroutine != null)
                StopCoroutine(coroutine);
            if (equippedRigidbody)
                Unequip();
        }

        private void Unequip() {
            if (!Flying.InAir)
                Friction.enabled = true;
            if (equipped) {
                Destroy(equipped);
                equipped = null;
            }
            //equippedRigidbody.mass = equippedMass;
            equippedRigidbody = null;
        }

    }
}
