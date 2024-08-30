using UnityEngine;

namespace CodeStyleGenius
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private Target[] _targets; 

        private int _currentPositionIndex;
        private int _nextPositionIndex;

        void Start()
        {
            Initialize();
        }

        public void Update()
        {
            Move();

            SetPositionsIndexes();
        }

        private void SetPositionsIndexes()
        {
            int indexIncreaser = 1;

            if (transform.position == _targets[_nextPositionIndex].transform.position)
            {
                _currentPositionIndex = _nextPositionIndex;
                _nextPositionIndex += indexIncreaser;

                if (_nextPositionIndex >= _targets.Length)
                {
                    _nextPositionIndex = 0;
                }
            }
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targets[_nextPositionIndex].transform.position, _speed * Time.deltaTime);
        }

        private void Initialize()
        {
            _currentPositionIndex = 0;
            _nextPositionIndex = _currentPositionIndex + 1;
        }
    }
}