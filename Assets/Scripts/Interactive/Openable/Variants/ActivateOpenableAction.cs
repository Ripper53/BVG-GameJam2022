using UnityEngine;

public class ActivateOpenableAction : OpenableAction {
    public GameObject GameObject;

    public override bool Open() {
        if (GameObject.activeSelf) return false;
        GameObject.SetActive(true);
        return true;
    }

}
