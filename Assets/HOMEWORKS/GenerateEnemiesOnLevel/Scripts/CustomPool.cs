using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class CustomPool : MonoBehaviour
    {
        [SerializeField] private int _capacity;

        private readonly Queue<Enemy> _pool = new Queue<Enemy>();

        public int Capacity => _capacity;
        public int Count => _pool.Count;

        public void AddObjectToPool(Enemy enemy)
        {
            _pool.Enqueue(enemy);
        }

        public Enemy GetObject()
        {
            Enemy enemy = _pool.Dequeue();

            return enemy;
        }
    }
}
