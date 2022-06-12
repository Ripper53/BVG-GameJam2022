using UnityEngine;
using TMPro;
using ArtificialIntelligence;

public class GemTracker : MonoBehaviour
{
    public Character Character;
    public FlyingAIWork Flying;

    private int RedGemsQuantity = 0;
    private int GreenGemsQuantity = 0;
    private int BlueGemsQuantity = 0;

    private bool IsBluePowerGemCollected = false;
    private bool IsRedPowerGemCollected = false;
    private bool IsGreenPowerGemCollected = false;

    public TMP_Text redGemText;
    public TMP_Text greenGemText;
    public TMP_Text blueGemText;

    public RedPowerData RedPower;
    [System.Serializable]
    public struct RedPowerData {
        public DashAIWork Power;
        public float MovementSpeed;
    }
    public BluePowerData BluePower;
    [System.Serializable]
    public struct BluePowerData {
        public LiftAIWork Power;
        public float MovementSpeed;
    }
    public GreenPowerData GreenPower;
    [System.Serializable]
    public struct GreenPowerData {
        public float MovementSpeed;
    }

    public GameManager GameManager;

    private void DestroyGem (Gem gem) {
        Renderer gemRenderer = gem.gameObject.GetComponent<Renderer>();
        gemRenderer.enabled = false;
        AudioSource gemAudio = gem.GetComponent<AudioSource>();
        gemAudio.Play();
        Destroy(gem.gameObject, gemAudio.clip.length);
    }

    private void CheckGameWin () {
        if (this.RedGemsQuantity == 1 && 
            this.BlueGemsQuantity == 1 && 
            this.GreenGemsQuantity == 1) {
            GameManager.WinGame();
        }
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
#if UNITY_EDITOR
                    Debug.Log($"Red gems amount: {RedGemsQuantity}");
#endif
                }
                break;
            case GemColour.Blue:
                if (this.IsBluePowerGemCollected) {
                    this.BlueGemsQuantity++;
                    blueGemText.text = $"x{this.BlueGemsQuantity}/10";
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
#if UNITY_EDITOR
                    Debug.Log($"Blue gems amount: {BlueGemsQuantity}");
#endif
                }
                break;
            case GemColour.Green:
                if (this.IsGreenPowerGemCollected) {
                    this.GreenGemsQuantity++;
                    greenGemText.text = $"x{this.GreenGemsQuantity}/10";
                    gem.IsCollected = true;
                    this.DestroyGem(gem);
#if UNITY_EDITOR
                    Debug.Log($"Green gems amount: {GreenGemsQuantity}");
#endif
                }
                break;
            default:
                break;
        }

        CheckGameWin();

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
                RedPower.Power.enabled = true;
                SetSpeed(RedPower.MovementSpeed);
                break;
            case GemColour.Blue:
                this.IsBluePowerGemCollected = true;
                BluePower.Power.enabled = true;
                SetSpeed(BluePower.MovementSpeed);
                break;
            case GemColour.Green:
                this.IsGreenPowerGemCollected = true;
                SetSpeed(GreenPower.MovementSpeed);
                break;
            default:
                break;
        }

        this.DestroyGem(gem);
    }

    private void DisableAllPowers() {
        RedPower.Power.enabled = false;
        BluePower.Power.enabled = false;
    }

    private void SetSpeed(float speed) {
        Character.MovementSpeed = speed;
        Flying.Speed = speed;
    }

}
