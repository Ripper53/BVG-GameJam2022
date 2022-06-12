using Physics.GetColliders;
using Physics.Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtificialIntelligence {
    public class AttackAIWork : MonoBehaviour {
        public BoxGetCollider GetCollider;
        public BoxShape BoxShape;

        public void Attack(Character.HorizontalMovementDirection direction) {
            Vector2 offset = BoxShape.Offset;
            offset.x = direction == Character.HorizontalMovementDirection.Right ? Mathf.Abs(offset.x) : -Mathf.Abs(offset.x);
            BoxShape.Offset = offset;
            //if (GetCollider.Get(out Collider2D collider) && collider.TryGetComponent(out ) {

            //}
        }

    }
}
