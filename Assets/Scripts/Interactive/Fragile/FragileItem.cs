using ArtificialIntelligence;
using Physics.GetColliders;
using UnityEngine;

public class FragileItem : MonoBehaviour {
    public FragileExecution Execution;
    public GetCollider GetCollider;

    protected void FixedUpdate() {
        if (!Execution.InDanger && GetCollider.Get(out Collider2D col) && col.TryGetComponent(out DashAIWork dash) && dash.InAir)
            Execution.Frail(col.attachedRigidbody.velocity);
    }

}
