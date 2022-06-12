using ArtificialIntelligence;
using Physics.GetColliders;
using UnityEngine;

public class FragileItem : MonoBehaviour {
    public FragileExecution Execution;
    public GetCollider GetCollider;
    public float CollisionSoundSpeed;

    protected void FixedUpdate() {
        if (!Execution.InDanger && GetCollider.Get(out Collider2D col) && col.TryGetComponent(out DashAIWork dash) && dash.InAir) {
            Execution.Frail(col.attachedRigidbody.velocity);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.sqrMagnitude > (CollisionSoundSpeed * CollisionSoundSpeed)) {
#if UNITY_EDITOR
            Debug.Log("EMITTED NOISE: " + gameObject.name, this);
#endif
            Execution.EmitNoise();
        }
    }

}
