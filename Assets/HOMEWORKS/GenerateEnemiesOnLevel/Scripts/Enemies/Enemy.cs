using System;
using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(Mover), typeof(Renderer))]
    public class Enemy : MonoBehaviour
    {
        protected float MovementSpeed;
        protected Color Color;

        private Mover _mover;

        private float _lifetime;

        private Coroutine _coroutine;

        public event Action<Enemy> Died;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Start()
        {
            Init();

            SetColor();

            _mover.SetSpeed(MovementSpeed);
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

        public void AddTargetPositionByLifetime(Vector3 direction)
        {
            _mover.AddTargetPositionBySpeed(direction * _lifetime);
        }

        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
        }

        protected virtual void Init()
        {
            MovementSpeed = 1;
            Color = Color.white;
        }

        private void SetColor()
        {
            GetComponent<Renderer>().material.color = Color;
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

