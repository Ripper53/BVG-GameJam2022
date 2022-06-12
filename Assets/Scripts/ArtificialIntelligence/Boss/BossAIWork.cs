using ArtificialIntelligence.Dependency;
using UnityEngine;
using Utility.Pooling;

namespace ArtificialIntelligence {
    public class BossAIWork : AIWork {
        public ProjectileData Projectile;
        [System.Serializable]
        public struct ProjectileData {
            public ProjectilePooler Pooler;
            public float Speed;
        }

        protected new Rigidbody2D rigidbody;
        protected TargetDependency targetDependency;

        protected override bool GetDependencies() {
            return TryGetComponent(out targetDependency) && TryGetComponent(out rigidbody);
        }

        private State currentState;
        private enum State {
            Projectile
        }
        protected override void Execute() {
            switch (currentState) {
                case State.Projectile:
                    ShootProjectile();
                    break;
            }
        }

        protected void ShootProjectile() {
            if (targetDependency.Get(out Vector2 target) && Projectile.Pooler.Get(out Projectile projectile)) {
                Vector2 diff = target - rigidbody.position;
                projectile.Set(rigidbody.position, Projectile.Speed * diff.normalized);
            }
        }

    }
}
