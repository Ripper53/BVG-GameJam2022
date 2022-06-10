using UnityEngine;

namespace Physics.Checks {
    public abstract class Check : MonoBehaviour {
        public abstract bool Evaluate();
    }
}
