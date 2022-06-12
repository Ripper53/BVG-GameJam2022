using UnityEngine;

public class OpenByPersuasion : MonoBehaviour, IPersuade {
    public Openable Openable;

    public void Persuade(Vector2 position) {
        Openable.Open();
    }

}
