using UnityEngine;

public class EndGameMenu : MonoBehaviour {
    public CameraControls CameraControls;
    public GameObject WinScreen, LoseScreen;

    public GameObject Player;

    //GameObject for the sound controller that plays music
    private GameObject soundControllerObject;

    private void DisableControls() {
        CameraControls.enabled = false;
        Time.timeScale = 0f;
    }

    public void WinGame() {
        DisableControls();

        //When the game is won, find the sound controller and then play song at index 3 (BVG Shanty)
        soundControllerObject = GameObject.Find("SoundController");
        soundControllerObject.SendMessage("PlayMusic", 3);


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
