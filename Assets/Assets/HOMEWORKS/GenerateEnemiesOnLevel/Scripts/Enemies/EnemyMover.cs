using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class EnemyMover : MonoBehaviour, IMovable
    {
        private TargetMover _target;
        private float _speed;

        private void Update()
        {
            Move(_target.transform.position, _speed);
        }

        public void Move(Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }

        public void SetSpeed(float speed)
        {
            if (speed > 0)
            {
                _speed = speed;
            }
        }

        public void SetTarget(TargetMover target)
        {
            _target = target;
        }
    }
}
