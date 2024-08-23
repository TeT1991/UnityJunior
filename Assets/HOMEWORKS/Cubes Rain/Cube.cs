using System;
using UnityEngine;

namespace CubesRain
{
    [RequireComponent(typeof(ColorChanger), typeof(Collider))]
    public class Cube : MonoBehaviour
    {
        private ColorChanger _colorChanger;
        private bool _isFirstTimeCollide;

        public event Action<Cube> CollidedFirstTime;

        private void Awake()
        {
            _colorChanger = GetComponent<ColorChanger>();
        }

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            _isFirstTimeCollide = false;
            _colorChanger.ResetColor();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(_isFirstTimeCollide == false && collision.gameObject.TryGetComponent<MainPlatform>(out MainPlatform platform))
            {
                _isFirstTimeCollide = true;
                CollidedFirstTime?.Invoke(this);
            }
        }
    }
}

