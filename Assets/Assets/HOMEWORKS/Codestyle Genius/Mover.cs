using UnityEngine;

namespace CodestyleGenius
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform[] _places;

        private float _speed;
        private Transform[] _targetPositions;
        private int _currentPosition;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _targetPositions = new Transform[_places.Length];

            for (int i = 0; i < _places.Length; i++)
            {
                    _targetPositions[i] = _places[i].transform;
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
                SelectNextPosition();
            }
        }

        private void Move()
        {
            var targetPosition = _targetPositions[_currentPosition];

            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
        }

        private void SelectNextPosition()
        {
            _currentPosition = (_currentPosition ++) % _targetPositions.Length;

            transform.forward = _targetPositions[_currentPosition].transform.position - transform.position;
        }
    }
}