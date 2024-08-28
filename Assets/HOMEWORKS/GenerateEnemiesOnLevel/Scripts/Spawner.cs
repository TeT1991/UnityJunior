using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(CustomPool<Enemy>))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private SpawnPoint[] _spawnPositions;

        private CustomPool<Enemy> _enemies;

        private Coroutine _coroutine;
        private float _spawnTime;

        private void Awake()
        {
            _enemies = GetComponent<CustomPool<Enemy>>();
            _spawnTime = 2;
        }

        private void Start()
        {
            _coroutine = StartCoroutine(SpawnEnemy(_spawnTime));
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private void TrySpawnEnemies()
        {
            Enemy enemy = _enemies.GetObject();

            if (enemy != null)
            {
                enemy.SetPosition(GetSpawnPosition());
                enemy.SetDirection(CalculateDirection());
                enemy.gameObject.SetActive(true);
                enemy.Died += ReleaseEnemy;
            }
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Died -= ReleaseEnemy;

            _enemies.TryAddObjectToPool(enemy);
        }

        private Vector3 GetSpawnPosition()
        {
            int minValue = 0;
            int maxValue = _spawnPositions.Length;
            int index = Random.Range(minValue, maxValue);

            return _spawnPositions[index].transform.position;
        }

        private Vector3 CalculateDirection()
        {
            float minValue = -1;
            float maxValue = 1;

            float x = Random.Range(minValue, maxValue);
            float y = Random.Range(minValue, maxValue);
            float z = Random.Range(minValue, maxValue);

            return new Vector3 (x, y, z);
        }

        private IEnumerator SpawnEnemy(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                TrySpawnEnemies();
                yield return wait;
            }
        }
    }
}

