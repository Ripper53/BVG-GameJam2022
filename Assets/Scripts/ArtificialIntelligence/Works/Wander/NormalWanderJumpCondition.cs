namespace ArtificialIntelligence {
    public class NormalWanderJumpCondition : WanderJumpCondition {

        public override bool ShouldJump(GroundCheck groundCheck, SideCheck checks) {
            return checks.AheadGroundCheck.Evaluate() && !checks.AboveGroundCheck.Evaluate();
        }

    }
}
