using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovementControls : PlayerControls {
    public Character Character;

    protected override void AddListeners(PlayerInput input) {
        input.Movement.Horizontal.performed += Horizontal_performed;
        input.Movement.Horizontal.canceled += Horizontal_canceled;

        input.Flying.Direction.performed += Direction_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Movement.Horizontal.performed -= Horizontal_performed;
        input.Movement.Horizontal.canceled -= Horizontal_canceled;

        input.Flying.Direction.performed -= Direction_performed;
    }

    private void Horizontal_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        Character.HorizontalDirection = obj.ReadValue<float>() > 0f ? Character.HorizontalMovementDirection.Right : Character.HorizontalMovementDirection.Left;
    }

    private void Horizontal_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        Character.HorizontalDirection = Character.HorizontalMovementDirection.None;
    }

    private void Direction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        
    }

}
