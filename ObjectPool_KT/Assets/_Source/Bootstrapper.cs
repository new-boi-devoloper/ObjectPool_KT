using System;
using UnityEngine;

namespace _Source
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PlayerShooter playerShooter;
        [SerializeField] private Bullet bullet;

        private IPool<Bullet> _objectPool;
        private const int _poolSize = 10;

        private void Awake()
        {
            _objectPool = new ObjectPool<Bullet>(bullet, _poolSize);

            inputListener.Construct(playerShooter);
            playerShooter.Construct(_objectPool);
        }
    }
}