namespace ArtificialIntelligence {
    public class NoWanderJumpCondition : WanderJumpCondition {

        public override bool ShouldJump(GroundCheck groundCheck, SideCheck checks) {
            return false;
        }

    }
}
