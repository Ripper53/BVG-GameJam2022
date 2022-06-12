using UnityEngine;

public abstract class FragileExecution : MonoBehaviour {
    public abstract bool InDanger { get; }
    public abstract void Frail(Vector2 velocity);
}
