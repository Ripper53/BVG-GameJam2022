using UnityEngine;

public class Openable : MonoBehaviour, IOpenable {
    public OpenableAction OpenableAction;

    public delegate void OpenedAction(Openable source);
    public event OpenedAction Opened;

    public void Open() {
        if (OpenableAction.Open())
            Opened?.Invoke(this);
    }

}
