using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class CubeEnemy : Enemy
    {
        protected override void Init()
        {
            base.Init();

            MovementSpeed = 2f;
            Color = Color.green;
        }
    }
}
