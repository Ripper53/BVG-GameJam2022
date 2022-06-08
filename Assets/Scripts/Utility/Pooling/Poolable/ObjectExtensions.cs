using UnityEngine;

namespace Utility.Pooling {
    public static class ObjectExtensions {

        /// <summary>
        /// Deactivates game object and adds it to its pooler.
        /// </summary>
        public static void AddToPool<T>(this T source) where T : Component, IPoolable<T> {
            source.gameObject.SetActive(false);
            source.Pooler.Add(source);
        }

    }
}
