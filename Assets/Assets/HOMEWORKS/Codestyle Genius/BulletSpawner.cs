using System.Collections;
using UnityEngine;

namespace CodeStyleGenius
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;

        [SerializeField] private float _bulletSpeed;

        [SerializeField] private Target _target;

        [SerializeField] private float _timeBetweenShoot;

        private ObjectsPool<Bullet> _bulletPool;
        private Coroutine _coroutine;

        void Start()
        {
            _coroutine = StartCoroutine(ShootCountdown(_timeBetweenShoot));
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
            bullet.Disabled -= ReleaseBullet;
            _bulletPool.ReturnObject(bullet);
        }

        IEnumerator ShootCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                var bullet = _bulletPool.GetObject();
                bullet.Init(CalculateDirection(), CalculateVelocity());
                bullet.Disabled += ReleaseBullet;

                yield return wait;
            }
        }
    }
}