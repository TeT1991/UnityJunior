using System.Collections;
using UnityEngine;

namespace CodestyleGenius
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private float _velocity;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _target;
        [SerializeField] private float _timeBetweenShot;

        private Coroutine _coroutine;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _coroutine = StartCoroutine(ShotingCountdown(_timeBetweenShot));
        }

        private IEnumerator ShotingCountdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                var direction = (_target.position - transform.position).normalized;
                var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                Rigidbody _rigidBody = bullet.GetComponent<Rigidbody>();

                _rigidBody.transform.up = direction;
                _rigidBody.velocity = direction * _velocity;

                yield return wait;
            }
        }
    }
}