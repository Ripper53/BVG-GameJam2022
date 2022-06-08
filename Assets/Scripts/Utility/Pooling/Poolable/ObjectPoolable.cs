using UnityEngine;
using Utility.Pooling.Base;

namespace Utility.Pooling {
    namespace Base {
        public class ObjectPoolable : MonoBehaviour, IPoolable {
            bool IPoolable.InPool { get; set; }
        }
    }
    /// <summary>
    /// Poolable object.
    /// </summary>
    /// <typeparam name="TSelf">The type itself.</typeparam>
    public class ObjectPoolable<TSelf> : ObjectPoolable, IPoolable<TSelf> where TSelf : ObjectPoolable<TSelf> {
        IPooler<TSelf> IPoolable<TSelf>.Pooler { get; set; }
    }
}
