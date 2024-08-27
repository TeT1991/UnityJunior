using System;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class Enemy : MonoBehaviour
    {
        private float _lifetime;

        public event Action<Enemy> Died;

        private void Start()
        {
            Invoke(nameof(Die), _lifetime);
        }

        public void SetLifetime(float lifetime)
        {
            float minLifetime = 2;

            if (lifetime > 0)
            {
                _lifetime = lifetime;
            }
            else
            {
                _lifetime = minLifetime;
            }
        }

        private void Die()
        {
            Died?.Invoke(this);
        }
    }
}

