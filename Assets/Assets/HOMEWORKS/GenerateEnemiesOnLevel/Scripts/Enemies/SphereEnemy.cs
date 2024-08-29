using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class SphereEnemy : Enemy
    {
        protected override void Init()
        {
            base.Init();

            MovementSpeed = 2.5f;
            Color = Color.gray;
        }
    }
}