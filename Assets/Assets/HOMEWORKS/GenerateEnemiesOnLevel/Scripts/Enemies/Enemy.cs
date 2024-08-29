using System;
using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(EnemyMover), typeof(Renderer))]
    public class Enemy : MonoBehaviour
    {
        protected float MovementSpeed;
        protected Color Color;

        private EnemyMover _mover;

        private float _lifetime;

        private Coroutine _coroutine;

        public event Action<Enemy> Died;

        private void Awake()
        {
            _mover = GetComponent<EnemyMover>();
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

        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
        }

        public void SetTarget (TargetMover target)
        {
            _mover.SetTarget(target);
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
            float minLifetime = 5;
            float maxLifetime = 20;

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

