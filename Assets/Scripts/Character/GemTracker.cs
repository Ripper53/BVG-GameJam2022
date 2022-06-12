using UnityEngine;
using TMPro;
using ArtificialIntelligence;
using Audio.Pooler;
using Utility.Pooling;
using Audio;

public class GemTracker : MonoBehaviour
{
    public Character Character;
    public EndGameMenu EndGameMenu;
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
        public TalkAIWork Power;
        public float MovementSpeed;
    }

    public GameManager GameManager;

    public GameObject RedPowerUpDialog;
    public GameObject GreenPowerUpDialog;
    public GameObject BluePowerUpDialog;

    public EffectData Effect;
    [System.Serializable]
    public struct EffectData {
        public OneShotAudioEffectPooler
            GemCollectEffectPooler,
            PowerGemCollectEffectPooler;
    }

    private void DestroyGem (Gem gem) {
        DestroyGem(gem, Effect.GemCollectEffectPooler);
    }

    private void DestroyGem (PowerGem powerGem) {
        DestroyGem(powerGem, Effect.PowerGemCollectEffectPooler);
    }

    private void DestroyGem(Gem gem, OneShotAudioEffectPooler pooler) {
        gem.gameObject.SetActive(false);
        if (pooler.Get(out OneShotAudioEffect effect)) {
            SetEffectColor(((OneShotAudioParticleEffect)effect).ParticleSystem, gem);
            effect.Set(gem.transform.position);
        }
    }

    private void SetEffectColor(ParticleSystem particleSystem, Gem gem) {
        ParticleSystem.MainModule main = particleSystem.main;
        switch (gem.Colour) {
            case GemColour.Red:
                main.startColor = new Color(255, 0, 0);
                break;
            case GemColour.Blue:
                main.startColor = new Color(0, 0, 255);
                break;
            case GemColour.Green:
                main.startColor = new Color(0, 255, 0);
                break;
        }
    }

    private void CheckGameWin () {
        if (this.RedGemsQuantity == 1 && 
            this.BlueGemsQuantity == 1 && 
            this.GreenGemsQuantity == 1) {
            EndGameMenu.WinGame();
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
                Character.gameObject.tag = "Red";
                this.IsRedPowerGemCollected = true;
                RedPower.Power.enabled = true;
                SetSpeed(RedPower.MovementSpeed);
                RedPowerUpDialog.gameObject.SetActive(true);
                Destroy(RedPowerUpDialog.gameObject, 5f);
                break;
            case GemColour.Blue:
                Character.gameObject.tag = "Blue";
                this.IsBluePowerGemCollected = true;
                BluePower.Power.enabled = true;
                SetSpeed(BluePower.MovementSpeed);
                BluePowerUpDialog.gameObject.SetActive(true);
                Destroy(BluePowerUpDialog.gameObject, 5f);
                break;
            case GemColour.Green:
                Character.gameObject.tag = "Green";
                this.IsGreenPowerGemCollected = true;
                GreenPower.Power.enabled = true;
                SetSpeed(GreenPower.MovementSpeed);
                GreenPowerUpDialog.gameObject.SetActive(true);
                Destroy(GreenPowerUpDialog.gameObject, 5f);
                break;
            default:
                break;
        }

        this.DestroyGem(gem);
    }

    private void DisableAllPowers() {
        RedPower.Power.enabled = false;
        BluePower.Power.enabled = false;
        GreenPower.Power.enabled = false;
    }

    private void SetSpeed(float speed) {
        Character.MovementSpeed = speed;
        Flying.Speed = speed;
    }

}
