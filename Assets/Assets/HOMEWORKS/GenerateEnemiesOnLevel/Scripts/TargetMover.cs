using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class TargetMover : MonoBehaviour, IMovable
    {
        [SerializeField] private float _speed;
        [SerializeField] private List<Vector3> _positions;
        [SerializeField] private bool _isLoopedPath; 

        private int _nextPositionIndex;
        private int _currentPositionIndex;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            Move(_positions[_nextPositionIndex], _speed);

            SetPositionsIndexes();

            TryStopMoving();
        }

        public void SetSpeed(float speed)
        {
            if (speed > 0)
            {
                _speed = speed;
            }
        }

        public void LoopPath()
        {
            _isLoopedPath = true;
        }

        public void Move(Vector3 nextPosition, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        }
         
        private void SetPositionsIndexes()
        {
            int indexIncreaser = 1;

            if (transform.position == _positions[_nextPositionIndex])
            {

                _currentPositionIndex = _nextPositionIndex;
                _nextPositionIndex += indexIncreaser;

                if (_nextPositionIndex >= _positions.Count)
                {
                    _nextPositionIndex = 0;
                }
            }
        }

        private void TryStopMoving()
        {
            if (_isLoopedPath == false && HasReachLastPoint() == true)
            {
                _speed = 0f;
            }
        }

        private bool HasReachLastPoint()
        {
            return transform.position == _positions[_positions.Count - 1];

        }

        private void Init()
        {
            int startIndex = 0;
            int indexIncreaser = 1;

            _positions.Insert(startIndex, transform.position);
            _currentPositionIndex = 0;
            _nextPositionIndex = _currentPositionIndex + indexIncreaser;
        }
    }
}