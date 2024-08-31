using UnityEngine;

namespace CodestyleGenius
{
    public class Mover : MonoBehaviour
    {
        private float _speed;
        private Transform _places;
        private Transform[] _targetPositions;
        private int _currentPosition;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _targetPositions = new Transform[_places.childCount];

            for (int i = 0; i < _places.childCount; i++)
            {
                if (_places.GetChild(i).TryGetComponent(out Transform transform))
                {
                    _targetPositions[i] = transform;
                }
            }
        }

        public void Update()
        {
            Move();
            TryGetNextPosition();
        }

        private void TryGetNextPosition()
        {
            if (transform.position == _targetPositions[_currentPosition].position)
            {
                GetNextPosition();
            }
        }

        private void Move()
        {
            var targetPosition = _targetPositions[_currentPosition];

            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
        }

        private void GetNextPosition()
        {
            _currentPosition++;

            if (_currentPosition == _targetPositions.Length)
            {
                _currentPosition = 0;
            }

            transform.forward = _targetPositions[_currentPosition].transform.position - transform.position;
        }
    }
}