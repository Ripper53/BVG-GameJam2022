using ArtificialIntelligence.Dependency;
using Physics.GetColliders;
using Physics.Shapes;
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

        public AttackAIWork Attack;

        protected new Rigidbody2D rigidbody;
        protected TargetDependency target;
        protected Jump.Jump jump;

        protected override bool GetDependencies() {
            return TryGetComponent(out target) && TryGetComponent(out jump) && TryGetComponent(out rigidbody);
        }

        public State CurrentState { get; private set; } = State.Idle;
        public enum State {
            Idle, Walking, Chase, Attack
        }

        private Vector2 latestTarget;
        private float moveTimer, idleTimer;
        protected override void Execute() {
            switch (CurrentState) {
                case State.Walking:
                    if (!CheckForAttack() && !CheckForChase()) {
                        moveTimer -= Time.fixedDeltaTime;
                        if (moveTimer <= 0f || character.HorizontalDirection == Character.HorizontalMovementDirection.None || ShouldHalt(CurrentSideCheck)) {
                            SetToIdle();
                        } else if (ShouldJump(CurrentSideCheck)) {
                            jump.Execute();
                        }
                    }
                    break;
                case State.Chase:
                    if (!CheckForAttack()) {
                        if (character.HorizontalDirection == Character.HorizontalMovementDirection.None || ShouldHalt(CurrentSideCheck))
                            SetToIdle();
                        else if (ShouldJump(CurrentSideCheck))
                            jump.Execute();
                    }
                    break;
                case State.Attack:
                    if (Attack.IsFinished)
                        CurrentState = State.Idle;
                    break;
                default: // Idle
                    if (!CheckForAttack() && !CheckForChase()) {
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
                    }
                    break;
            }
        }

        private bool CheckForAttack() {
            if (Attack.Detection.Detect()) {
                CurrentState = State.Attack;
                character.HorizontalDirection = Character.HorizontalMovementDirection.None;
                Attack.Attack();
                return true;
            }
            return false;
        }

        private bool CheckForChase() {
            if (target.Get(out latestTarget)) {
                float diff = latestTarget.x - rigidbody.position.x;
                if (diff > 0f) {
                    if (!ShouldHalt(Right)) {
                        CurrentState = State.Chase;
                        character.HorizontalDirection = Character.HorizontalMovementDirection.Right;
                        return true;
                    }
                } else if (!ShouldHalt(Left)) {
                    CurrentState = State.Chase;
                    character.HorizontalDirection = Character.HorizontalMovementDirection.Left;
                    return true;
                }
            }
            return false;
        }

        private void SetToIdle() {
            character.HorizontalDirection = Character.HorizontalMovementDirection.None;
            idleTimer = Random.Range(MinIdleTime, MaxIdleTime);
            CurrentState = State.Idle;
        }

        private void SetToMove() {
            moveTimer = Random.Range(MinMoveTime, MaxMoveTime);
            CurrentState = State.Walking;
        }

        private SideCheck CurrentSideCheck => character.HorizontalDirection == Character.HorizontalMovementDirection.Right ? Right : Left;

        private bool ShouldHalt(SideCheck checks) {
            return Mathf.Abs(latestTarget.x - rigidbody.position.x) < 1f || HaltCondition.ShouldHalt(GroundCheck, checks);
        }

        private bool ShouldJump(SideCheck checks) {
            return JumpCondition.ShouldJump(GroundCheck, checks);
        }

        public void Noise(Vector2 position) {
            latestTarget = Distraction.GetNoiseDistraction(position);
            Distract();
        }

        public void Food(Vector2 position) {
            latestTarget = Distraction.GetFoodDistraction(position);
            Distract();
        }

        private void Distract() {
            float diff = latestTarget.x - rigidbody.position.x;
            character.HorizontalDirection = diff > 0f ? Character.HorizontalMovementDirection.Right : Character.HorizontalMovementDirection.Left;
            moveTimer = Mathf.Abs((diff / Mathf.Max(1f, character.MovementSpeed)) - 0.25f);
            CurrentState = State.Walking;
        }

    }
}
