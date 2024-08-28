using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(Mover))]
    public class Enemy : MonoBehaviour
    {
        private Mover _mover;

        private float _lifetime;

        private Coroutine _coroutine;

        public event Action<Enemy> Died;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void OnEnable()
        {
            CalculateLifetime();
            _coroutine = StartCoroutine(LifetimeCountdown(_lifetime));
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private void Start()
        {
            Debug.Log(_lifetime);
        }

        public void SetDirection(Vector3 direction)
        {
            _mover.SetDirection(direction);
        }

        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
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

