using ArtificialIntelligence;
using UnityEngine;

public class SwitchAbility : MonoBehaviour {
    public Character Character;
    public SpriteRenderer SpriteRenderer;
    public FlyingAIWork Flying;

    #region Data
    public interface IPowerData {
        public AIWork Power { get; }
        public float GroundSpeed { get; }
        public float FlySpeed { get; }
        public bool Learned { get; }
        public Color Color { get; }
    }
    public RedPowerData RedPower;
    [System.Serializable]
    public struct RedPowerData : IPowerData {
        public DashAIWork Power;
        public float GroundSpeed, FlySpeed;
        public Color Color;
        AIWork IPowerData.Power => Power;
        float IPowerData.GroundSpeed => GroundSpeed;
        float IPowerData.FlySpeed => FlySpeed;
        Color IPowerData.Color => Color;
        public bool Learned { get; set; }
    }
    public BluePowerData BluePower;
    [System.Serializable]
    public struct BluePowerData : IPowerData {
        public LiftAIWork Power;
        public float GroundSpeed, FlySpeed;
        public Color Color;
        AIWork IPowerData.Power => Power;
        float IPowerData.GroundSpeed => GroundSpeed;
        float IPowerData.FlySpeed => FlySpeed;
        Color IPowerData.Color => Color;
        public bool Learned { get; set; }
    }
    public GreenPowerData GreenPower;
    [System.Serializable]
    public struct GreenPowerData : IPowerData {
        public TalkAIWork Power;
        public float GroundSpeed, FlySpeed;
        public Color Color;
        AIWork IPowerData.Power => Power;
        float IPowerData.GroundSpeed => GroundSpeed;
        float IPowerData.FlySpeed => FlySpeed;
        Color IPowerData.Color => Color;
        public bool Learned { get; set; }
    }
    #endregion

    public void ActivateRed() {
        Character.gameObject.tag = "Red";
        ActivatePower(RedPower);
    }

    public void ActivateBlue() {
        Character.gameObject.tag = "Blue";
        ActivatePower(BluePower);
    }

    public void ActivateGreen() {
        Character.gameObject.tag = "Green";
        ActivatePower(GreenPower);
    }

    private void ActivatePower(IPowerData power) {
        if (!power.Learned) return;

        DisableAll();
        power.Power.enabled = true;

        Character.MovementSpeed = power.GroundSpeed;
        Flying.Speed = power.FlySpeed;

        SpriteRenderer.color = power.Color;
    }

    private void DisableAll() {
        RedPower.Power.enabled = false;
        BluePower.Power.enabled = false;
        GreenPower.Power.enabled = false;
    }

}
