using UnityEngine;

public abstract class GroundFriction : MonoBehaviour {
    public Character Character;
    public Rigidbody2D Rigidbody;
    public GroundCheck GroundCheck;

    protected void FixedUpdate() {
        if (GroundCheck.EvaluateBelowGroundOnly()) {
            ExecuteOnGround();
        } else {
            ExecuteInAir();
        }
    }

    protected abstract void ExecuteOnGround();
    protected abstract void ExecuteInAir();

}
