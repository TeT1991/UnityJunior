using System;
using UnityEngine;

namespace CodeStyleGenius
{
    [RequireComponent(typeof(BulletMover))]
    public class Bullet : MonoBehaviour
    {
        private BulletMover _bulletMover;

        public event Action<Bullet> Destroyed;

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }

        public void Init(Vector3 direction, Vector3 velocity)
        {
            transform.rotation = Quaternion.Euler(direction);
            _bulletMover = GetComponent<BulletMover>();
            _bulletMover.Init(velocity);
        }
    }
}