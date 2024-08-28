using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(CustomPool<Enemy>))]
    public class Spawner : MonoBehaviour
    {
        protected CustomPool<Enemy> _enemies;

        protected Coroutine _coroutine;
        private float _spawnTime;

        protected virtual void Awake()
        {
            _enemies = GetComponent<CustomPool<Enemy>>();
            _spawnTime = 2;
        }

        protected void Start()
        {
            _coroutine = StartCoroutine(SpawnEnemy(_spawnTime));
        }

        protected void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        protected void TrySpawnEnemies()
        {
            Debug.Log("!!!!");

            Enemy enemy = _enemies.GetObject();
            Debug.Log(enemy);

            if (enemy != null)
            {
                enemy.SetPosition(transform.position);
                enemy.AddTargetPositionByLifetime(CalculateDirection());
                enemy.gameObject.SetActive(true);
                enemy.Died += ReleaseEnemy;
            }
        }

        protected void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Died -= ReleaseEnemy;

            _enemies.TryAddObjectToPool(enemy);
        }

        protected Vector3 CalculateDirection()
        {
            float minValue = -1;
            float maxValue = 1;

            float x = Random.Range(minValue, maxValue);
            float y = Random.Range(minValue, maxValue);
            float z = Random.Range(minValue, maxValue);

            return new Vector3 (x, y, z);
        }

        protected IEnumerator SpawnEnemy(float delay)
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

