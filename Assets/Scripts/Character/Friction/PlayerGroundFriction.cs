using UnityEngine;

public class PlayerGroundFriction : GroundFriction {
    [Tooltip("Rigidbody.drag")]
    public float GroundDrag;
    [Tooltip("velocity.x * AirDrag")]
    [Range(0f, 1f)]
    public float AirDrag;

    protected override void ExecuteOnGround() {
        Rigidbody.drag = Character.HorizontalDirection == Character.HorizontalMovementDirection.None ? GroundDrag : 0f;
    }

    protected override void ExecuteInAir() {
        Rigidbody.drag = 0f;
        if (Character.HorizontalDirection == Character.HorizontalMovementDirection.None)
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x * AirDrag, Rigidbody.velocity.y);
    }

}
