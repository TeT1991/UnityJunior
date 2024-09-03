using System.Collections;
using UnityEngine;

namespace CodestyleGenius
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private float _velocity;

        [SerializeField] private Bullet _prefab;
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
                var direction = (_target.position - transform.position).normalized;
                var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

                rigidbody.transform.up = direction;
                rigidbody.velocity = direction * _velocity;

                yield return wait;
            }
        }
    }
}