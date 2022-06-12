using UnityEngine;

public class EndGameMenu : MonoBehaviour {
    public CameraControls CameraControls;
    public GameObject WinScreen, LoseScreen;

    public GameObject Player;

    private void DisableControls() {
        CameraControls.enabled = false;
        Time.timeScale = 0f;
    }

    public void WinGame() {
        DisableControls();
        WinScreen.SetActive(true);
    }

    public void LoseGame() {
        DisableControls();
        LoseScreen.SetActive(true);
    }

    protected void OnDisable() {
        Time.timeScale = 1f;
    }

}
