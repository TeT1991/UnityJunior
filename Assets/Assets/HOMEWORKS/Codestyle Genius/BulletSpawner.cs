using System.Collections;
using UnityEngine;

namespace CodeStyleGenius
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] Bullet _prefab;

        [SerializeField] public float _bulletSpeed;

        [SerializeField] private Target _target;

        [SerializeField] private float _timeBetweenShoot;

        private readonly ObjectsPool<Bullet> _bulletPool;

        void Start()
        {
            StartCoroutine(ShootCountdown(_timeBetweenShoot));
        }

        private Vector3 CalculateDirection()
        {
            return (_target.transform.position - transform.position).normalized;
        }

        private Vector3 CalculateVelocity()
        {
            return CalculateDirection() * _bulletSpeed;
        }

        private void ReleaseBullet(Bullet bullet)
        {
            bullet.Destroyed -= ReleaseBullet;
            _bulletPool.ReturnObject(bullet);
        }

        IEnumerator ShootCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                var bullet = _bulletPool.GetObject();
                bullet.Init(CalculateDirection(), CalculateVelocity());
                bullet.Destroyed += ReleaseBullet;

                yield return wait;
            }
        }
    }
}