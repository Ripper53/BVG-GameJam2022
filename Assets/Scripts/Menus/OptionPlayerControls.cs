public class OptionPlayerControls : PlayerControls {
    public SoundController SoundController;

    protected override void AddListeners(PlayerInput input) {
        input.Option.MuteMusic.performed += MuteMusic_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Option.MuteMusic.performed -= MuteMusic_performed;
    }

    private float savedMusicVolume = 1f;
    private void MuteMusic_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (SoundController.MusicVolume == 0f) {
            SoundController.MusicVolume = savedMusicVolume;
        } else {
            savedMusicVolume = SoundController.MusicVolume;
            SoundController.MusicVolume = 0f;
        }
    }

}
