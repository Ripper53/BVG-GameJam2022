using Physics.GetColliders;
using UnityEngine;

public class SoundFragileExecutor : FragileExecution {
    public Transform DistractionPoint;
    public GetCollider SoundGetCollider;

    public override bool InDanger => false;

    public override void EmitNoise() {
        foreach (Collider2D col in SoundGetCollider.Get()) {
            if (col.TryGetComponent(out IDistract distract))
                distract.Noise(DistractionPoint.position);
        }
    }

    public override void Frail(Vector2 velocity) {
        EmitNoise();
    }

}
