using System.Collections.Generic;
using UnityEngine;

namespace _Source
{
    public interface IPool<T> where T : Object, IPooledObject
    {
        int Count { get; }
        bool TryGetFromPool(out T pooledObject);
        void ReturnToPool(T pooledObject);
    }

    public class ObjectPool<T> : IPool<T> where T : Object, IPooledObject
    {
        private Queue<T> pool = new Queue<T>();
        private T _prefab;

        public int Count => pool.Count;

        public ObjectPool(T prefab, int poolSize)
        {
            this._prefab = prefab;
            InitPool(poolSize);
        }

        private void InitPool(int poolSize)
        {
            for (var i = 0; i < poolSize; i++)
            {
                var objectInstance = Object.Instantiate(_prefab);
                objectInstance.OnPooledObjectReturn += (obj) => ReturnToPool((T)obj); // ?0.0?
                objectInstance.SetActive(false);
                pool.Enqueue(objectInstance);
            }
        }

        public void ReturnToPool(T pooledObject)
        {
            pooledObject.SetActive(false);
            pool.Enqueue(pooledObject);
        }

        public bool TryGetFromPool(out T pooledObject)
        {
            if (pool.Count > 0)
            {
                pooledObject = pool.Dequeue();
                pooledObject.SetActive(true);
                return true;
            }

            pooledObject = default(T);
            return false;
        }
    }
}