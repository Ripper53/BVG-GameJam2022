using UnityEngine;

public enum GemColour {Red, Blue, Green};
public class Gem : MonoBehaviour
{
    public GemColour Colour;

    public bool IsCollected = false;

    protected virtual void CollectGem (Collider2D other) {
        other.GetComponent<GemTracker>().CollectCollectableGem(this);
#if UNITY_EDITOR
        Debug.Log($"Touched a {Colour} gem");
#endif
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        this.CollectGem(other);
    }
}
