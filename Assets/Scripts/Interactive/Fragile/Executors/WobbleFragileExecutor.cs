using UnityEngine;

public class WobbleFragileExecutor : SoundFragileExecutor {
    public Rigidbody2D Rigidbody;
    public float MaxVelocity;

    public override void Frail(Vector2 velocity) {
        Rigidbody.velocity = Vector2.ClampMagnitude(velocity, MaxVelocity);
        base.Frail(velocity);
    }

}
