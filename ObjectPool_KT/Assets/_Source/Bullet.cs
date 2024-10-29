using System;
using System.Collections;
using UnityEngine;

namespace _Source
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        public float speed = 20f;
        public float lifetime = 2f;

        public event Action<IPooledObject> OnPooledObjectReturn;

        private void FixedUpdate()
        {
            // Двигаем пулю вперед
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }

        private void OnEnable()
        {
            // Запускаем корутину для таймера жизни пули
            StartCoroutine(LifetimeTimer());
        }

        public void OnReturnToPool()
        {
            OnPooledObjectReturn?.Invoke(this);
        }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        private IEnumerator LifetimeTimer()
        {
            // Ждем lifetime секунд
            yield return new WaitForSeconds(lifetime);

            // Возвращаем пулю в пул по истечении времени жизни
            OnReturnToPool();
        }
    }
}