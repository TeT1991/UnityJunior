using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public Vector3 _direction;

        private void Update()
        {
            transform.Translate(_direction * _speed);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}

