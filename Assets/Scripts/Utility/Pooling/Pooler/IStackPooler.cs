using System.Collections.Generic;

namespace Utility.Pooling.Base {
    public interface IStackPooler<T> : IPooler<T> where T : IPoolable<T> {
        /// <summary>
        /// Stores pooled instance of <typeparamref name="T"/>.
        /// </summary>
        protected Stack<T> Collection { get; }
        bool IPooler<T>.Get(out T value) {
            if (Collection.TryPop(out value)) {
                value.InPool = false;
                return true;
            }
            if (CreateIfNotMax(out value)) {
                value = CreateNew();
                value.InPool = false;
                return true;
            }
            return false;
        }

        private bool CreateIfNotMax(out T value) {
            if (Count < Capacity) {
                Count += 1;
                value = CreateNew();
                value.Pooler = this;
                return true;
            }
            value = default;
            return false;
        }

        void IPooler<T>.Add(T value) {
            value.InPool = true;
            Collection.Push(value);
        }

        /// <summary>
        /// Return a new instance of <typeparamref name="T"/>.
        /// </summary>
        protected T CreateNew();
    }
}
