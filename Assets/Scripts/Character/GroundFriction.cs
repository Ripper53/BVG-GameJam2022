using Physics.Checks;
using UnityEngine;

public class GroundFriction : MonoBehaviour {
    public Character Character;
    public Rigidbody2D Rigidbody;
    public Check Check;
    [Tooltip("Rigidbody.drag")]
    public float GroundDrag;
    [Tooltip("velocity.x * AirDrag")]
    [Range(0f, 1f)]
    public float AirDrag;

    protected void FixedUpdate() {
        if (Check.Evaluate()) {
            Rigidbody.drag = Character.HorizontalDirection == Character.HorizontalMovementDirection.None ? GroundDrag : 0f;
        } else if (Character.HorizontalDirection == Character.HorizontalMovementDirection.None) {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x * AirDrag, Rigidbody.velocity.y);
        }
    }

}
