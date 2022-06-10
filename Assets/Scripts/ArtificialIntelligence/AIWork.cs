using UnityEngine;

namespace ArtificialIntelligence {
    public abstract class AIWork : MonoBehaviour {
        protected Character character;

        /// <summary>
        /// Called every <see cref="FixedUpdate"/> if all dependencies exist.
        /// </summary>
        protected abstract void Execute();

        private bool hasAllDependencies = false;
        protected void Start() {
            character = GetComponent<Character>();
            hasAllDependencies = GetDependencies();
#if UNITY_EDITOR
            if (!hasAllDependencies)
                Debug.LogWarning("All dependencies were not found for: " + gameObject.name, this);
#endif
        }
        /// <returns>True if all dependencies exist, otherwise false.</returns>
        protected abstract bool GetDependencies();

        protected void FixedUpdate() {
            if (hasAllDependencies)
                Execute();
        }

    }
}
