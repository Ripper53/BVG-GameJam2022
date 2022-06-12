using ArtificialIntelligence.Dependency;
using UnityEngine;

namespace ArtificialIntelligence {
    public class WanderAIWork : AIWork, IDistract {
        public float MinMoveTime, MaxMoveTime;
        public float MinIdleTime, MaxIdleTime;
        public GroundCheck GroundCheck;
        public SideCheck Right, Left;
        public WanderHaltCondition HaltCondition;
        public WanderJumpCondition JumpCondition;
        public WanderDistraction Distraction;

        protected new Rigidbody2D rigidbody;
        protected TargetDependency target;
        protected Jump.Jump jump;

        protected override bool GetDependencies() {
            return TryGetComponent(out target) && TryGetComponent(out jump) && TryGetComponent(out rigidbody);
        }

        private State currentState = State.Idle;
        private enum State {
            Idle, Walking, Chase
        }

        private Vector2 latestTarget;
        private float moveTimer, idleTimer;
        protected override void Execute() {
            if (target.Get(out latestTarget)) {
                currentState = State.Chase;
            }
            switch (currentState) {
                case State.Walking:
                    moveTimer -= Time.fixedDeltaTime;
                    if (moveTimer <= 0f || character.HorizontalDirection == Character.HorizontalMovementDirection.None || ShouldHalt(CurrentSideCheck)) {
                        character.HorizontalDirection = Character.HorizontalMovementDirection.None;
                        SetToIdle();
                    } else if (ShouldJump(CurrentSideCheck)) {
                        jump.Execute();
                    }
                    break;
                case State.Chase:

                    break;
                default: // Idle
                    idleTimer -= Time.fixedDeltaTime;
                    if (idleTimer <= 0f) {
                        if (Right.WallCheck.Evaluate() && !ShouldJump(Right))
                            character.HorizontalDirection = Character.HorizontalMovementDirection.Left;
                        else if (Left.WallCheck.Evaluate() && !ShouldJump(Left))
                            character.HorizontalDirection = Character.HorizontalMovementDirection.Right;
                        else
                            character.HorizontalDirection = Random.Range(0, 2) == 0 ? Character.HorizontalMovementDirection.Right : Character.HorizontalMovementDirection.Left;
                        SetToMove();
                    }
                    break;
            }
        }

        private void SetToIdle() {
            idleTimer = Random.Range(MinIdleTime, MaxIdleTime);
            currentState = State.Idle;
        }

        private void SetToMove() {
            moveTimer = Random.Range(MinMoveTime, MaxMoveTime);
            currentState = State.Walking;
        }

        private SideCheck CurrentSideCheck => character.HorizontalDirection == Character.HorizontalMovementDirection.Right ? Right : Left;

        private bool ShouldHalt(SideCheck checks) {
            return HaltCondition.ShouldHalt(GroundCheck, checks);
        }

        private bool ShouldJump(SideCheck checks) {
            return JumpCondition.ShouldJump(GroundCheck, checks);
        }

        public void Distract(Vector2 position) {
            latestTarget = Distraction.GetDistraction(position);
            float diff = latestTarget.x - rigidbody.position.x;
            character.HorizontalDirection = diff > 0f ? Character.HorizontalMovementDirection.Right : Character.HorizontalMovementDirection.Left;
            moveTimer = Mathf.Abs((diff / Mathf.Max(1f, character.MovementSpeed)) - 0.25f);
            currentState = State.Walking;
        }

    }
}
