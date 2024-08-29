using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(EnemyMover), typeof(Renderer))]
    public class Enemy : MonoBehaviour
    {
        protected float MovementSpeed;
        protected Color Color;

        private EnemyMover _mover;


        private Coroutine _coroutine;

        public event Action<Enemy> Died;

        private void Awake()
        {
            _mover = GetComponent<EnemyMover>();
            Init();
        }

        private void Start()
        {
            SetColor();
        }


        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void SetParametrs(Vector3 position, TargetMover target)
        {
            gameObject.transform.position = position;
            _mover.Init(MovementSpeed, target);
        }

        protected virtual void Init()
        {
            MovementSpeed = 1;
            Color = Color.white;
            _mover.ReachedTarget += Die;
        }

        private void SetColor()
        {
            GetComponent<Renderer>().material.color = Color;
        }

        protected void Die()
        {
            Died?.Invoke(this);
        }
    }
}

