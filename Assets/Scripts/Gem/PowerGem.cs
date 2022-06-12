using UnityEngine;

public class PowerGem : Gem
{

    protected override void CollectGem (Collider2D other) {
        other.GetComponent<GemTracker>().CollectPowerGem(this);
        this.IsCollected = true;
#if UNITY_EDITOR
        Debug.Log($"Touched a Power {Colour} gem");
#endif
    }

}
