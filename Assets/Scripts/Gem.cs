using UnityEngine;

public enum GemColour {Red, Blue, Green};
public class Gem : MonoBehaviour
{
    public GemColour Colour;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<GemTracker>().CollectGem(this);

        Debug.Log($"Touched a {Colour} gem");
    }
}
