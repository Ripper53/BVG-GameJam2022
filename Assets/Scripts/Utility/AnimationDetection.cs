using UnityEngine;

public abstract class AnimationDetection : MonoBehaviour {

    protected void OnTriggerEnter2D(Collider2D collision) {
        ActivateAnimation();
    }

    protected void OnTriggerExit2D(Collider2D collision) {
        DeactivateAnimation();
    }

    protected abstract void ActivateAnimation();
    protected abstract void DeactivateAnimation();

}
