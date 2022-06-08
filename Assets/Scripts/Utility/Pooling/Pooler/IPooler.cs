using Utility.Pooling.Base;

namespace Utility.Pooling {
    namespace Base {
        public interface IPooler {
            /// <summary>
            /// Maximum amount of pooled prefabs.
            /// </summary>
            public int Capacity { get; }

            /// <summary>
            /// Current amount of pooled prefabs.
            /// </summary>
            public int Count { get; protected set; }
        }
    }
    /// <summary>
    /// Pools instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of intances to pool.</typeparam>
    public interface IPooler<T> : IPooler where T : IPoolable<T> {
        /// <returns>True if a pooled instance was set to <paramref name="value"/>, otherwise false.</returns>
        public bool Get(out T value);
        /// <summary>
        /// Add <paramref name="value"/> to pool.
        /// </summary>
        internal void Add(T value);
    }
}
