using UnityEngine;
using TMPro;
using ArtificialIntelligence;

public class GemTracker : MonoBehaviour
{

    private int RedGemsQuantity = 0;
    private int GreenGemsQuantity = 0;
    private int BlueGemsQuantity = 0;

    private bool IsBluePowerGemCollected = false;
    private bool IsRedPowerGemCollected = false;
    private bool IsGreenPowerGemCollected = false;

    public TMP_Text redGemText;
    public TMP_Text greenGemText;
    public TMP_Text blueGemText;

    public DashAIWork RedPower;

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
                    redGemText.text = $"x{this.RedGemsQuantity}/10";
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
                    Debug.Log($"Red gems amount: {RedGemsQuantity}");
                }
                break;
            case GemColour.Blue:
                if (this.IsBluePowerGemCollected) {
                    this.BlueGemsQuantity++;
                    blueGemText.text = $"x{this.BlueGemsQuantity}/10";
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
                    Debug.Log($"Blue gems amount: {BlueGemsQuantity}");
                }
                break;
            case GemColour.Green:
                if (this.IsGreenPowerGemCollected) {
                    this.GreenGemsQuantity++;
                    greenGemText.text = $"x{this.GreenGemsQuantity}/10";
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

        DisableAllPowers();
        GemColour gemColour = gem.Colour;
        switch (gemColour)
        {
            case GemColour.Red:
                this.IsRedPowerGemCollected = true;
                RedPower.enabled = true;
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

    private void DisableAllPowers() {
        RedPower.enabled = false;
    }

}
