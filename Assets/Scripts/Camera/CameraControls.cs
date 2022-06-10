using UnityEngine;

public class CameraControls : PlayerControls {
    public Camera Camera;
    private Vector2 LastPoint;

    public float sensitivity = 0.15f;
    private Vector2 targetPosition = Vector2.zero;
    private Rect screenRect = Rect.zero;
    [Space (8)]
    public float offsetMoveSpeed = 25f;
    private Vector3 cameraOffset = Vector2.zero;

    public Transform playerTrasnform;

    protected override void AddListeners(PlayerInput input) {
        input.Camera.PointerPosition.performed += Pointer_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Camera.PointerPosition.performed -= Pointer_performed;
    }

    private void Pointer_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        Vector2 mousePos = obj.ReadValue<Vector2>();

        screenRect = new Rect (0f, 0f, Screen.width, Screen.height);

        cameraOffset.x = Mathf.MoveTowards (cameraOffset.x, 0f, offsetMoveSpeed * Time.fixedDeltaTime);

        if (screenRect.Contains (mousePos))
            targetPosition = Camera.main.ScreenToWorldPoint (mousePos) + cameraOffset;

        Vector2 linearInterpolation = Vector2.Lerp (playerTrasnform.position, targetPosition, sensitivity);
        Camera.transform.position = new Vector3(linearInterpolation.x, linearInterpolation.y, -10);
    }

}
