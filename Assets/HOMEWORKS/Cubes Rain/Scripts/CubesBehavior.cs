using System.Collections;
using UnityEngine;

namespace CubesRain
{
    [RequireComponent(typeof(CubesCreator), typeof(CustomPool))]
    public class CubesBehavior : MonoBehaviour
    {
        private CubesCreator _creator;
        private CustomPool _pool;

        private Coroutine _coroutine;
        private float _timeBetweenSpawn;

        private void Awake()
        {
            _creator = GetComponent<CubesCreator>();
            _pool = GetComponent<CustomPool>();

            _timeBetweenSpawn = 1;
        }

        private void Start()
        {
            _coroutine = StartCoroutine(SpawnCountdown());
        }

        private void OnDestroy()
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private void LaunchBehavior()
        {
            Cube cube = GetOrCreateCube();
            cube.transform.position = CalculateNewPosition();
            cube.gameObject.SetActive(true);
        }

        private Cube GetOrCreateCube()
        {
            Cube cube;

            if(_pool.Count == 0)
            {
                cube = _creator.CreateCube(CalculateNewPosition());
                cube.Released += _pool.ReleaseObject;
            }
            else
            {
                cube = _pool.GetObject();
            }

            return cube;
        }

        private Vector3 CalculateNewPosition()
        {
            float minValue = -5;
            float maxValue = 5;

            float x = Random.Range(minValue, maxValue);
            float y = transform.position.y;
            float z = Random.Range(minValue, maxValue);

            return new Vector3(x, y, z);
        }

        private IEnumerator SpawnCountdown()
        {
            var wait = new WaitForSeconds(_timeBetweenSpawn);

            while (enabled)
            {
                LaunchBehavior();
                yield return wait;
            }
        }
    }
}

