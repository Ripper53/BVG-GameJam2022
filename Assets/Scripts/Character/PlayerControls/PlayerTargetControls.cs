using ArtificialIntelligence.Dependency;
using UnityEngine;

public class PlayerTargetControls : PlayerControls {
    public Camera Camera;
    public Rigidbody2D Rigidbody;
    public PlayerTargetDependency TargetDependency;
    public PlayerAbilityDependency AbilityDependency;

    protected override void AddListeners(PlayerInput input) {
        pointerPosition = Rigidbody.position;

        input.Flying.LiftOff.performed += LiftOff_performed;
        input.Flying.LiftOff.canceled += LiftOff_canceled;

        input.Ability.Primary.performed += Primary_performed;
        input.Ability.Primary.canceled += Primary_canceled;

        input.Flying.Direction.performed += Direction_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Flying.LiftOff.performed -= LiftOff_performed;
        input.Flying.LiftOff.canceled -= LiftOff_canceled;

        input.Ability.Primary.performed -= Primary_performed;
        input.Ability.Primary.canceled -= Primary_canceled;

        input.Flying.Direction.performed -= Direction_performed;
    }

    private void Primary_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        AbilityDependency.Triggered = true;
        AbilityDependency.Hold = true;
    }

    private void Primary_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        AbilityDependency.Hold = false;
    }

    private void LiftOff_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        TargetDependency.Active = true;
    }

    private void LiftOff_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        TargetDependency.Active = false;
    }

    private Vector2 pointerPosition;
    private void Direction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        pointerPosition = obj.ReadValue<Vector2>();
    }

    protected void Update() {
        Vector2 target = Camera.ScreenToWorldPoint(pointerPosition);
        TargetDependency.Target = target;
        AbilityDependency.Target = target;
    }

}
