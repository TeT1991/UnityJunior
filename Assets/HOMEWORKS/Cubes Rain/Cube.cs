using System;
using UnityEngine;

namespace CubesRain
{
    [RequireComponent(typeof(ColorChanger), typeof(Collider))]
    public class Cube : MonoBehaviour
    {
        private ColorChanger _colorChanger;
        private bool _isFirstTimeCollide;

        public event Action<Cube> Released;

        private void Awake()
        {
            _colorChanger = GetComponent<ColorChanger>();
        }

        private void Start()
        {
            Reset();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isFirstTimeCollide == false && collision.gameObject.TryGetComponent<MainPlatform>(out MainPlatform platform))
            {
                _isFirstTimeCollide = true;
                _colorChanger.ChangeColor();

                Invoke(nameof(Release), GetRandomLifetime());
            }
        }

        public void Reset()
        {
            _isFirstTimeCollide = false;
            _colorChanger.ResetColor();
        }

        private void Release()
        {
            Released?.Invoke(this);
        }

        private float GetRandomLifetime()
        {
            float minLifetime = 2;
            float maxLifetime = 5;

            return UnityEngine.Random.Range(minLifetime, maxLifetime);
        }
    }
}

