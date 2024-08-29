using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    [RequireComponent(typeof(EnemiesPool))]
    public class SphereEnemiesSpawner : Spawner
    {
        protected override void Awake()
        {
            Enemies = GetComponent<EnemiesPool>(); 
            SpawnTime = 1;
        }
    }
}
