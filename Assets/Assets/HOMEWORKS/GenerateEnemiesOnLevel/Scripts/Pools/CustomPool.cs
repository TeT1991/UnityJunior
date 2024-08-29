using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class CustomPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T Prefab;
        [SerializeField] private int _capacity;

        protected Queue<T> Objects = new Queue<T>();

        public int Capacity => _capacity;
        public int Count => Objects.Count;

        public void TryAddObjectToPool(T obj)
        {
            if (Count < Capacity)
            {
                Objects.Enqueue(obj);
            }
            else
            {
                Destroy(obj);
            }
        }

        public T GetObject()
        {
            T obj;

            if (Objects.Count == 0)
            {
                obj = Instantiate(Prefab);
            }
            else
            {
                obj = Objects.Dequeue();
            }

            return obj;
        }
    }
}
