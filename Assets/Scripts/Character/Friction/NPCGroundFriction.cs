using UnityEngine;

public class NPCGroundFriction : GroundFriction {
    [Tooltip("Rigidbody.drag")]
    public float GroundDrag;

    protected override void ExecuteOnGround() {
        Rigidbody.drag = Character.HorizontalDirection == Character.HorizontalMovementDirection.None ? GroundDrag : 0f;
    }

    protected override void ExecuteInAir() {
        Rigidbody.drag = 0f;
    }

}
