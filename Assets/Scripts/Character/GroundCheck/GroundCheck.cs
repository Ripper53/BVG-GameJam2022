using Physics.Checks;
using UnityEngine;

public class GroundCheck : Check {
    [SerializeField]
    private Check check;
    [SerializeField]
    private Check belowCheck;
    public float CoyoteTime;

    private bool evaluateCache = false;
    public override bool Evaluate() => evaluateCache;
    public bool EvaluateBelowGroundOnly() => disableTimer <= 0f && belowCheck.Evaluate();

    private float disableTimer = 0f, coyoteTimer = 0f;

    public void DisableFor(float time) {
        disableTimer = time;
        coyoteTimer = 0f;
        evaluateCache = false;
    }

    protected void OnEnable() {
        disableTimer = 0f;
        coyoteTimer = 0f;
        evaluateCache = false;
    }

    /// <summary>
    /// Executes before default time!
    /// </summary>
    protected void FixedUpdate() {
        evaluateCache = false;
        if (disableTimer > 0f) {
            disableTimer -= Time.fixedDeltaTime;
        } else if (check.Evaluate()) {
            coyoteTimer = CoyoteTime;
            evaluateCache = true;
        } else if (coyoteTimer > 0f) {
            coyoteTimer -= Time.fixedDeltaTime;
            evaluateCache = true;
        }
    }

}
