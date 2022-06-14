using Physics.Checks;
using UnityEngine;
using Utility.Pooling;

public class Character : ObjectPoolable<Character> {
    public Movement.Movement Movement;
    public Movement.MovementExecutor MovementExecutor;
    public GroundCheck GroundCheck;
    public SideCheck RightSideCheck, LeftSideCheck;
    public float MovementSpeed;

    public delegate void StateChangedAction(HorizontalMovementDirection direction);
    public event StateChangedAction HorizontalDirectionChanged;
    private HorizontalMovementDirection horizontalDirection = HorizontalMovementDirection.None;
    public HorizontalMovementDirection HorizontalDirection {
        get => horizontalDirection;
        set {
            if (horizontalDirection != value) {
                horizontalDirection = value;
                HorizontalDirectionChanged?.Invoke(value);
            }
        }
    }
    public enum HorizontalMovementDirection {
        None, Right, Left
    }

    protected void FixedUpdate() {
        switch (HorizontalDirection) {
            case HorizontalMovementDirection.Right:
                MoveInDirection(MovementSpeed * Time.fixedDeltaTime, RightSideCheck.WallCheck);
                break;
            case HorizontalMovementDirection.Left:
                MoveInDirection(-MovementSpeed * Time.fixedDeltaTime, LeftSideCheck.WallCheck);
                break;
        }
    }

    private void MoveInDirection(float amount, Check wallCheck) {
        if (GroundCheck.Evaluate() && !wallCheck.Evaluate()) {
            MovementExecutor.Activate();
            Movement.Move(amount);
        } else {
            MovementExecutor.Deactivate();
        }
    }

}
