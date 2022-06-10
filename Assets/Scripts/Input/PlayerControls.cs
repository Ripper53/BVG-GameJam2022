using UnityEngine;

public abstract class PlayerControls : MonoBehaviour {
    private PlayerInput input;

    protected void Awake() {
        input = new PlayerInput();
    }

    protected void OnEnable() {
        AddListeners(input);
        input.Enable();
    }

    protected void OnDisable() {
        input.Disable();
        RemoveListeners(input);
    }

    protected abstract void AddListeners(PlayerInput input);
    protected abstract void RemoveListeners(PlayerInput input);

}
