namespace ArtificialIntelligence {
    public class NormalWanderHaltCondition : WanderHaltCondition {

        public override bool ShouldHalt(GroundCheck groundCheck, SideCheck checks) {
            return (checks.WallCheck.Evaluate() && checks.AboveGroundCheck.Evaluate()) || (groundCheck.Evaluate() && !checks.BelowGroundCheck.Evaluate());
        }

    }
}
