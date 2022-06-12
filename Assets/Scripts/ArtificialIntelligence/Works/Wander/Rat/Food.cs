using Physics.GetColliders;
using UnityEngine;

public class Food : MonoBehaviour {
    public Transform DistractPoint;
    public GetCollider GetCollider;
    public string Tag;

    protected void FixedUpdate() {
        foreach (Collider2D col in GetCollider.Get()) {
            if (col.CompareTag(Tag) && col.TryGetComponent(out IDistract distract))
                distract.Food(DistractPoint.position);
        }
    }

}
