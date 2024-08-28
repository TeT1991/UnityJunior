using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(CubeEnemyPool))]
    public class CubesEnemiesSpawner : Spawner
    {
        protected override void Awake()
        {
            _enemies = GetComponent<CubeEnemyPool>();
        }
    }
}
