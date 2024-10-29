using UnityEngine;

namespace _Source
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        private IPool<Bullet> _objectPool;

        public void Construct(IPool<Bullet> objectPool)
        {
            _objectPool = objectPool;
        }

        public void Shoot()
        {
            if (_objectPool.TryGetFromPool(out var pooledObject))
            {
                Debug.Log("Invoked Shoot");
                // Приводим IPooledObject к GameObject
                var bulletInstance = pooledObject as Bullet;
                if (bulletInstance != null)
                {
                    Debug.Log("Toke Bullet class");

                    // Устанавливаем позицию и направление пули
                    bulletInstance.transform.position = firePoint.position;
                    bulletInstance.transform.rotation = firePoint.rotation;
                }
            }
        }
    }
}