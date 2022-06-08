using Utility.Pooling.Base;

namespace Utility.Pooling {
    namespace Base {
        public interface IPoolable {
            public bool InPool { get; internal set; }
        }
    }
    /// <summary>
    /// Poolable instance.
    /// </summary>
    /// <typeparam name="TSelf">The type itself.</typeparam>
    public interface IPoolable<TSelf> : IPoolable where TSelf : IPoolable<TSelf> {
        public IPooler<TSelf> Pooler { get; internal set; }
    }
}
