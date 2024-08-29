using System;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class EnemyMover : MonoBehaviour, IMovable
    {
        private TargetMover _target;
        private float _speed;

        public event Action ReachedTarget;

        private void Update()
        {
            Move(_target.transform.position, _speed);
            HasReachedTerget();
        }

        public void Move(Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }

        public void Init(float speed, TargetMover target)
        {
            if (speed > 0)
            {
                _speed = speed;
            }

            _target = target;
        }

        private void HasReachedTerget()
        {
            float minValue = 0.06f;

            if( Vector3.Distance(transform.position, _target.transform.position) <= minValue) 
            {
                ReachedTarget?.Invoke();
            }
        }
    }
}
