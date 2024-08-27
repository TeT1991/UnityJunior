using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(CustomPool))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private SpawnPoint[] _spawnPositions;

        private CustomPool _pool;

        private Coroutine _coroutine;
        private float _spawnTime;

        private void Awake()
        {
            _pool = GetComponent<CustomPool>();
            _spawnTime = 2;
        }

        private void Start()
        {
            _coroutine = StartCoroutine(SpawnEnemy(_spawnTime));
        }

        private void SpawnEnemy()
        {
            Enemy enemy;

            if(_pool.Count > 0)
            {
                enemy = _pool.GetObject();
            }
            else
            {
                enemy = Instantiate(_prefab);
            }

            enemy.transform.SetPositionAndRotation(GetSpawnPosition(), CalculateRotation());
            enemy.SetLifetime(CalculateLifeTime());
            enemy.gameObject.SetActive(true);
            enemy.Died += ReleaseEnemy;
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Died -= ReleaseEnemy;

            if(_pool.Count < _pool.Capacity)
            {
                _pool.AddObjectToPool(enemy);
                return;
            }

            Destroy(enemy.gameObject);
        }

        private Vector3 GetSpawnPosition()
        {
            int minValue = 0;
            int maxValue = _spawnPositions.Length;
            int index = Random.Range(minValue, maxValue);

            return _spawnPositions[index].transform.position;
        }

        private Quaternion CalculateRotation()
        {
            float minValue = 0;
            float maxValue = 360;

            float x = 0;
            float y = Random.Range(minValue, maxValue);
            float z = 0;

            Quaternion rotation = Quaternion.Euler(x, y, z);

            return rotation;
        }

        private float CalculateLifeTime()
        {
            float minLifetime = 2;
            float maxTime = 6;

            return Random.Range(minLifetime, maxTime);
        }

        private IEnumerator SpawnEnemy(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                SpawnEnemy();
                yield return wait;
            }
        }
    }
}

