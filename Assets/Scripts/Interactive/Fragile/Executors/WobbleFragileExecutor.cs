using Physics.GetColliders;
using UnityEngine;

public class WobbleFragileExecutor : FragileExecution {
    public Transform Transform, DistractionPoint;
    public GetCollider SoundGetCollider;
    public float WobbleDuration;
    public float MinTilt = 10f, MaxTilt = 80f;

    private float wobbleTimer;
    public override bool InDanger => wobbleTimer > 0f;

    private float maxTilt, direction;
    public override void Frail(Vector2 velocity) {
        wobbleTimer = WobbleDuration;
        direction = velocity.x;
        maxTilt = Mathf.Clamp(Mathf.Abs(direction), MinTilt, MaxTilt);
        enabled = true;
        EmitNoise();
    }
    public override void EmitNoise() {
        foreach (Collider2D col in SoundGetCollider.Get()) {
            if (col.TryGetComponent(out IDistract distract))
                distract.Noise(DistractionPoint.position);
        }
    }

    protected void OnDisable() {
        SetAngle(0f);
    }

    protected void FixedUpdate() {
        wobbleTimer -= Time.fixedDeltaTime;
        if (wobbleTimer <= 0f)
            enabled = false;
    }

    protected void Update() {
        if (!InDanger) return;
        SetAngle(Angle + (direction * Time.deltaTime));
        if (Mathf.Abs(Angle) > maxTilt)
            ReachedEndOfTilt();
        if (direction > 0f) {
           
        } else {

        }
    }

    private void ReachedEndOfTilt() {
        SetAngle(maxTilt * direction);
        maxTilt *= 0.5f;
        direction = -direction;
    }

    private float Angle => Transform.eulerAngles.z;
    private void SetAngle(float angle) => Transform.rotation = Quaternion.Euler(0f, 0f, angle);

}
