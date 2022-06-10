using Physics.Checks;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    [SerializeField]
    private Check check;
    public bool Evalute() => check.Evaluate();
}
