using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    public Character Character;
    public SpriteRenderer SpriteRenderer;

    protected void Update() {
        switch (Character.HorizontalDirection) {
            case Character.HorizontalMovementDirection.Right:
                SpriteRenderer.flipX = false;
                break;
            case Character.HorizontalMovementDirection.Left:
                SpriteRenderer.flipX = true;
                break;
        }
    }

}
