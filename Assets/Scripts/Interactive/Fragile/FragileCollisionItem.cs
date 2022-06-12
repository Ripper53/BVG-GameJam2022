using UnityEngine;

public class FragileCollisionItem : MonoBehaviour {
    public FragileExecution Execution;
    public float CollisionSoundSpeed;

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.sqrMagnitude > (CollisionSoundSpeed * CollisionSoundSpeed)) {
#if UNITY_EDITOR
            Debug.Log("EMITTED NOISE: " + gameObject.name, this);
#endif
            Execution.EmitNoise();
        }
    }

}
