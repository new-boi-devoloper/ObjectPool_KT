using System;
using UnityEngine;

namespace _Source
{
    public interface IPooledObject
    {
        public event Action<IPooledObject> OnPooledObjectReturn;
        void OnReturnToPool();
        void SetActive(bool state);
    }
}