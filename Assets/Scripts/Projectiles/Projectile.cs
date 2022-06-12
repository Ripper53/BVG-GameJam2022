using UnityEngine;
using Utility.Pooling;

public class Projectile : ObjectPoolable<Projectile> {
    public Transform Transform;
    public Rigidbody2D Rigidbody;

    public void Set(Vector2 position, Vector2 velocity) {
        Transform.position = position;
        gameObject.SetActive(true);
        Rigidbody.velocity = velocity;
    }

}
