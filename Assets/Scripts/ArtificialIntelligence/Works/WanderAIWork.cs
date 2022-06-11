using ArtificialIntelligence.Dependency;
using UnityEngine;

namespace ArtificialIntelligence {
    public class WanderAIWork : AIWork {
        public float MinMoveTime, MaxMoveTime;
        public float MinIdleTime, MaxIdleTime;
        public GroundCheck GroundCheck;
        public SideCheck Right, Left;

        protected TargetDependency target;
        protected Jump.Jump jump;

        protected override bool GetDependencies() {
            return TryGetComponent(out target) && TryGetComponent(out jump);
        }

        private Vector2 latestTarget;
        private float moveTimer, idleTimer;
        protected override void Execute() {
            if (target.Get(out latestTarget)) {

            } else if (moveTimer > 0f) {
                moveTimer -= Time.fixedDeltaTime;
                if (moveTimer <= 0f || character.HorizontalDirection == Character.HorizontalMovementDirection.None || ShouldHalt(CurrentSideCheck)) {
                    character.HorizontalDirection = Character.HorizontalMovementDirection.None;
                    idleTimer = Random.Range(MinIdleTime, MaxIdleTime);
                } else if (ShouldJump(CurrentSideCheck)) {
                    jump.Execute();
                }
            } else if (idleTimer > 0f) {
                idleTimer -= Time.fixedDeltaTime;
            } else {
                if (Right.WallCheck.Evaluate() && Right.AboveGroundCheck.Evaluate())
                    character.HorizontalDirection = Character.HorizontalMovementDirection.Left;
                else if (Left.WallCheck.Evaluate() && Left.AboveGroundCheck.Evaluate())
                    character.HorizontalDirection = Character.HorizontalMovementDirection.Right;
                else
                    character.HorizontalDirection = Random.Range(0, 2) == 0 ? Character.HorizontalMovementDirection.Right : Character.HorizontalMovementDirection.Left;
                moveTimer = Random.Range(MinMoveTime, MaxMoveTime);
            }
        }

        private SideCheck CurrentSideCheck => character.HorizontalDirection == Character.HorizontalMovementDirection.Right ? Right : Left;

        private bool ShouldHalt(SideCheck checks) {
            return (checks.WallCheck.Evaluate() && checks.AboveGroundCheck.Evaluate()) || (GroundCheck.Evaluate() && !checks.BelowGroundCheck.Evaluate());
        }

        private bool ShouldJump(SideCheck checks) {
            return checks.AheadGroundCheck.Evaluate() && !checks.AboveGroundCheck.Evaluate();
        }

    }
}
