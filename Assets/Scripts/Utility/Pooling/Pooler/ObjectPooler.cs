using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling.Base;

namespace Utility.Pooling {
    public static class ObjectPooler {
        public static bool Get<T>(this IPooler<T> pooler, out T value) where T : IPoolable<T> {
            return pooler.Get(out value);
        }
    }
    /// <summary>
    /// Pools objects of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of objects to pool.</typeparam>
    public class ObjectPooler<T> : MonoBehaviour, IStackPooler<T> where T : Object, IPoolable<T> {
        [Tooltip("Prefab to instantiate and add to pool.")]
        public T Prefab;
        [Tooltip("Maximum amount of pooled prefabs.")]
        public int Capacity;
        int IPooler.Capacity => Capacity;

        int IPooler.Count { get; set; } = 0;

        Stack<T> IStackPooler<T>.Collection { get; } = new Stack<T>();

        T IStackPooler<T>.CreateNew() => Instantiate(Prefab);

    }
}
