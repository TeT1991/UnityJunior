using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(EnemiesPool))]
    public class CubesEnemiesSpawner : Spawner<CubeEnemy>
    {
        protected override void Awake()
        {
            Enemies = GetComponent<EnemiesPool>();
            SpawnTime = 5;
        }
    }
}
