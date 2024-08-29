using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class CubeEnemy : Enemy
    {
        protected override void Init()
        {
            MovementSpeed = 0.3f;
            Color = Color.green;
        }
    }
}
