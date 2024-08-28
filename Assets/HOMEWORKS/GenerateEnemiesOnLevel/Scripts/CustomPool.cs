using System.Collections.Generic;
using UnityEngine;

namespace GenerationEnemiesOnLevel
{
    public class CustomPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private int _capacity;
        [SerializeField] private T _prefab;

        private readonly Queue<T> _objects = new Queue<T>();

        public int Capacity => _capacity;
        public int Count => _objects.Count;

        public void TryAddObjectToPool(T obj)
        {
            if (Count < Capacity)
            {
                Debug.Log("ENQ");
                _objects.Enqueue(obj);
            }
            else
            {
                Debug.Log("DESTR");
                Destroy(obj);
            }
        }

        public T GetObject()
        {
            T obj;

            if (_objects.Count == 0)
            {
                Debug.Log("INST");
                obj = Instantiate(_prefab);
            }
            else
            {
                Debug.Log("QUE");
                obj = _objects.Dequeue();
            }

            return obj;
        }
    }
}
