using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class Enemy : MonoBehaviour
    {
        private float _lifetime;

        private Coroutine _coroutine;

        public event Action<Enemy> Died;

        private void OnEnable()
        {
            CalculateLifetime();
            _coroutine = StartCoroutine(LifetimeCountdown(_lifetime));
        }

        private void Start()
        {
            Debug.Log(_lifetime);
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            gameObject.transform.SetPositionAndRotation(position, rotation);
        }

        private void CalculateLifetime()
        {
            float minLifetime = 2;
            float maxLifetime = 5;

            _lifetime = UnityEngine.Random.Range(minLifetime, maxLifetime);
        }

        private void Die()
        {
            Died?.Invoke(this);
        }

        private IEnumerator LifetimeCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                Die();
                yield return wait;
            }
        }
    }
}

