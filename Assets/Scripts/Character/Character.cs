using UnityEngine;
using Utility.Pooling;

public class Character : ObjectPoolable<Character> {
    public Movement.Movement Movement;
    public GroundCheck GroundCheck;
    public float MovementSpeed;

    public HorizontalMovementDirection HorizontalDirection;
    public enum HorizontalMovementDirection {
        None, Right, Left
    }

    protected void FixedUpdate() {
        Movement.enabled = GroundCheck.Evalute();
        switch (HorizontalDirection) {
            case HorizontalMovementDirection.Right:
                Movement.Move(new Vector2(MovementSpeed * Time.fixedDeltaTime, 0f));
                break;
            case HorizontalMovementDirection.Left:
                Movement.Move(new Vector2(-MovementSpeed * Time.fixedDeltaTime, 0f));
                break;
        }
    }

}
