using UnityEngine;

public class CameraControls : PlayerControls {
    public Camera Camera;
    private Vector2 LastPoint;

    public float Sensitivity = 0.15f;
    private Vector2 TargetPosition = Vector2.zero;
    private Rect ScreenRect = Rect.zero;
    [Space (8)]
    public float OffsetMoveSpeed = 25f;
    private Vector3 CameraOffset = Vector2.zero;

    public Transform PlayerTrasnform;

    private Vector2 MousePosition;

    protected override void AddListeners(PlayerInput input) {
        input.Camera.PointerPosition.performed += Pointer_performed;
    }

    protected override void RemoveListeners(PlayerInput input) {
        input.Camera.PointerPosition.performed -= Pointer_performed;
    }

    private void Pointer_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        MousePosition = obj.ReadValue<Vector2>();
    }

    private void Update () {
        ScreenRect = new Rect (0f, 0f, Screen.width, Screen.height);

        CameraOffset.x = Mathf.MoveTowards (CameraOffset.x, 0f, OffsetMoveSpeed * Time.fixedDeltaTime);

        if (ScreenRect.Contains (MousePosition))
            TargetPosition = Camera.ScreenToWorldPoint (MousePosition) + CameraOffset;

        Vector2 linearInterpolation = Vector2.Lerp (PlayerTrasnform.position, TargetPosition, Sensitivity);
        Camera.transform.position = new Vector3(linearInterpolation.x, linearInterpolation.y, -10);
    }

}
