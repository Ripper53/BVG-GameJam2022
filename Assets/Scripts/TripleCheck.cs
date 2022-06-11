using Physics.Checks;

public class TripleCheck : Check {
    public Check Check1, Check2, Check3;

    public override bool Evaluate() => Check1.Evaluate() || Check2.Evaluate() || Check3.Evaluate();

}
