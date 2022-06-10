using ArtificialIntelligence.Dependency;
using UnityEngine;

public class PlayerTargetControls : PlayerControls {
    public Camera Camera;
    public Rigidbody2D Rigidbody;
    public PlayerTargetDependency TargetDependency;

    protected override void AddListeners(PlayerInput input) {
        input.Flying.LiftOff.performed += LiftOff_performed;
        input.Flying.LiftOff.canceled += LiftOff_canceled;

        input.Flying.Direction.performed += Direction_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Flying.LiftOff.performed += LiftOff_performed;
        input.Flying.LiftOff.canceled += LiftOff_canceled;

        input.Flying.Direction.performed -= Direction_performed;
    }

    private void LiftOff_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        TargetDependency.Active = true;
    }

    private void LiftOff_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        TargetDependency.Active = false;
    }

    private void Direction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        TargetDependency.Target = Camera.ScreenToWorldPoint(obj.ReadValue<Vector2>());
    }

}
