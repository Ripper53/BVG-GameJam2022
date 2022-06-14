using UnityEngine;

namespace Physics.Checks {
    public class ExclusiveCheck : Check {
        public GameObject ToExclude;
        public Check Check;

        public override bool Evaluate() {
            int savedLayer = ToExclude.layer;
            ToExclude.layer = 2;
            bool value = Check.Evaluate();
            ToExclude.layer = savedLayer;
            return value;
        }

    }
}
