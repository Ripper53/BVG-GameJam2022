using UnityEngine;

public class ColliderOpenableAction : OpenableAction {
    public Collider2D Collider;

    public override bool Open() {
        if (!Collider.enabled) return false;
        Collider.enabled = false;
        return true;
    }

}
