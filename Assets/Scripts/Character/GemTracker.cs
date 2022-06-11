using UnityEngine;

public class GemTracker : MonoBehaviour
{

    private int RedGemsQuantity = 0;
    private int GreenGemsQuantity = 0;
    private int BlueGemsQuantity = 0;

    private bool IsBluePowerGemCollected = false;
    private bool IsRedPowerGemCollected = false;
    private bool IsGreenPowerGemCollected = false;

    private void DestroyGem (Gem gem) {
        Renderer gemRenderer = gem.gameObject.GetComponent<Renderer>();
        gemRenderer.enabled = false;
        AudioSource gemAudio = gem.GetComponent<AudioSource>();
        gemAudio.Play();
        Destroy(gem.gameObject, gemAudio.clip.length);
    }

    public void CollectCollectableGem (Gem gem) {
        if (gem.IsCollected) {
            return;
        }

        GemColour gemColour = gem.Colour;

        switch (gemColour)
        {
            case GemColour.Red:
                if (this.IsRedPowerGemCollected) {
                    this.RedGemsQuantity++;
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
                    Debug.Log($"Red gems amount: {RedGemsQuantity}");
                }
                break;
            case GemColour.Blue:
                if (this.IsBluePowerGemCollected) {
                    this.BlueGemsQuantity++;
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
                    Debug.Log($"Blue gems amount: {BlueGemsQuantity}");
                }
                break;
            case GemColour.Green:
                if (this.IsGreenPowerGemCollected) {
                    this.GreenGemsQuantity++;
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
                    Debug.Log($"Green gems amount: {GreenGemsQuantity}");
                }
                break;
            default:
                break;
        }

        //TODO
        // Spawn another gem?
    }

    public void CollectPowerGem(PowerGem gem) {
        if (gem.IsCollected) {
            return;
        }

        GemColour gemColour = gem.Colour;
        switch (gemColour)
        {
            case GemColour.Red:
                this.IsRedPowerGemCollected = true;
                break;
            case GemColour.Blue:
                this.IsBluePowerGemCollected = true;
                break;
            case GemColour.Green:
                this.IsGreenPowerGemCollected = true;
                break;
            default:
                break;
        }

        // TODO Gave power to player

        this.DestroyGem(gem);
    }
}
