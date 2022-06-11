using UnityEngine;

public class PowerGem : Gem
{
    private bool PowerCollected = false;

    protected override void CollectGem (Collider2D other) {
        other.GetComponent<GemTracker>().CollectPowerGem(this);
        this.IsCollected = true;
        Debug.Log($"Touched a Power {Colour} gem");
    }

    void GivePower () {
        if (this.PowerCollected) {
            return;
        }

        Debug.Log("You received a power!");
        //TODO give power

        this.PowerCollected = true;
    }
}
