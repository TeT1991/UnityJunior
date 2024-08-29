using System.Collections;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(CustomPool<Enemy>))]
    public class Spawner<T> : MonoBehaviour where T: Enemy
    {
        [SerializeField] private TargetMover _target;

        protected CustomPool<Enemy> Enemies; 

        protected float SpawnTime;

        private Coroutine _coroutine;

        protected virtual void Awake()
        {
            Enemies = GetComponent<CustomPool<Enemy>>();
            _target = GetComponent<TargetMover>();
            SpawnTime = 2;
        }

        private void Start()
        {
            _coroutine = StartCoroutine(SpawnEnemy(SpawnTime));
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private void TrySpawnEnemies()
        {
            Enemy enemy = Enemies.GetObject();

            if (enemy != null)
            {
                enemy.SetParametrs(transform.position, _target);
                enemy.gameObject.SetActive(true);
                enemy.Died += ReleaseEnemy;
            }
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Died -= ReleaseEnemy;

            Enemies.TryAddObjectToPool(enemy);
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

