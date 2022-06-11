using UnityEngine;

public enum GemColour {Red, Blue, Green};
public class Gem : MonoBehaviour
{
    public GemColour Colour;

    public bool IsCollected = false;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<GemTracker>().CollectGem(this);

        this.IsCollected = true;

        Debug.Log($"Touched a {Colour} gem");
    }
}
