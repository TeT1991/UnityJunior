using System.Collections;
using UnityEngine;

namespace CodestyleGenius
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private float _velocity;

        [SerializeField] private BulletMover _prefab;
        [SerializeField] private Transform _target;
        [SerializeField] private float _timeBetweenShot;

        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(ShotingCountdown(_timeBetweenShot));
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator ShotingCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                Vector3 direction = (_target.position - transform.position).normalized;

                BulletMover bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
                bullet.SetDirection(direction);
                bullet.SetVelocity(_velocity);

                yield return wait;
            }
        }
    }
}