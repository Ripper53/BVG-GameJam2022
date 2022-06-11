using UnityEngine;

public class GemTracker : MonoBehaviour
{

    private int RedGemsQuantity = 0;
    private int GreenGemsQuantity = 0;
    private int BlueGemsQuantity = 0;

    public void CollectGem (Gem gem) {
        if (gem.IsCollected) {
            return;
        }

        GemColour gemColour = gem.Colour;
        switch (gemColour)
        {
            case GemColour.Red:
                RedGemsQuantity++;
                break;
            case GemColour.Blue:
                BlueGemsQuantity++;
                break;
            case GemColour.Green:
                GreenGemsQuantity++;
                break;
            default:
                break;
        }

        Debug.Log($"Red gems amount: {RedGemsQuantity}");
        Debug.Log($"Blue gems amount: {BlueGemsQuantity}");
        Debug.Log($"Green gems amount: {GreenGemsQuantity}");

        Renderer gemRenderer = gem.gameObject.GetComponent<Renderer>();
        gemRenderer.enabled = false;
        AudioSource gemAudio = gem.GetComponent<AudioSource>();
        gemAudio.Play();
        Destroy(gem.gameObject, gemAudio.clip.length);

        //TODO
        // Spawn another gem?
        // Gave power to player
    }
}
