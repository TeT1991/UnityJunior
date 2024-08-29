using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(EnemiesPool))]
    public class SphereEnemiesSpawner : Spawner<SphereEnemy>
    {
        protected override void Awake()
        {
            Enemies = GetComponent<EnemiesPool>(); 
            SpawnTime = 7;
        }
    }
}
