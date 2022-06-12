using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpPopup : MonoBehaviour
{
    public Transform CameraTransform;

    void Awake () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "UI";
    }

    void Update () {
        this.transform.position = new Vector3(CameraTransform.position.x, CameraTransform.position.y + 2, CameraTransform.position.z);
    }
}
