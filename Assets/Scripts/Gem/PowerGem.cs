using UnityEngine;

public class PowerGem : Gem
{
    private ParticleSystem particles;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        var main = particles.main;

        switch (Colour)
        {
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

    protected override void CollectGem (Collider2D other) {
        other.GetComponent<GemTracker>().CollectPowerGem(this);
        this.IsCollected = true;
#if UNITY_EDITOR
        Debug.Log($"Touched a Power {Colour} gem");
#endif
    }

}
