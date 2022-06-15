using System.Collections.Generic;
using UnityEngine;

namespace Physics.GetColliders {
    public class ExclusiveGetCollider : GetCollider {
        public GameObject ToExclude;
        public GetCollider GetCollider;

        public override bool Get(out Collider2D collider) {
            int savedLayer = ToExclude.layer;
            ToExclude.layer = 2;
            bool value = GetCollider.Get(out collider);
            ToExclude.layer = savedLayer;
            return value;
        }

        public override IEnumerable<Collider2D> Get() {
            int savedLayer = ToExclude.layer;
            ToExclude.layer = 2;
            IEnumerable<Collider2D> value = GetCollider.Get();
            ToExclude.layer = savedLayer;
            return value;
        }

    }
}
