using UnityEngine;

public class Openable : MonoBehaviour, IOpenable {
    public Collider2D Collider;

    public delegate void OpenedAction(Openable source);
    public event OpenedAction Opened;

    public void Open() {
        if (!Collider.enabled) return;
        Collider.enabled = false;
        Opened?.Invoke(this);
    }

}
