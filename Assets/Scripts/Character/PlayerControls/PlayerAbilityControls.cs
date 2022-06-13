public class PlayerAbilityControls : PlayerControls {
    public SwitchAbility SwitchAbility;

    protected override void AddListeners(PlayerInput input) {
        input.Ability.Ability1.performed += Ability1_performed;
        input.Ability.Ability2.performed += Ability2_performed;
        input.Ability.Ability3.performed += Ability3_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Ability.Ability1.performed -= Ability1_performed;
        input.Ability.Ability2.performed -= Ability2_performed;
        input.Ability.Ability3.performed -= Ability3_performed;
    }

    private void Ability1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        SwitchAbility.ActivateRed();
    }

    private void Ability2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        SwitchAbility.ActivateBlue();
    }

    private void Ability3_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        SwitchAbility.ActivateGreen();
    }

}
