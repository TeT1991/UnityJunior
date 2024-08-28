using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class SphereEnemy : Enemy
    {
        protected override void Init()
        {
            MovementSpeed = 0.5f;
            Color = Color.gray;
        }
    }
}