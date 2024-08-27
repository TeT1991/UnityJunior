using System.Collections.Generic;
using UnityEngine;

namespace CubesRain
{
    public class CustomPool : MonoBehaviour
    {
        [SerializeField] private int _capacity;
        [SerializeField] private int _timeToFirstLauch;
        [SerializeField] private int _delay;

        private Queue<Cube> _pool = new Queue<Cube>();

        public int Capacity => _capacity;
        public int Count => _pool.Count;

        public void AddObjectToPool(Cube cube)
        {
            _pool.Enqueue(cube);
        }

        public Cube GetObject()
        {
            Cube cube = _pool.Dequeue();
            cube.Reset();
            cube.gameObject.SetActive(true);

            return cube;
        }

        public void ReleaseObject(Cube obj)
        {
            obj.gameObject.SetActive(false);
            TryReturnObjectToPool(obj);
        }

        private void TryReturnObjectToPool(Cube obj)
        {
            if (_pool.Count < _capacity)
            {
                AddObjectToPool(obj);
            }
            else
            {
                DestroyObject(obj);
            }
        }

        private void DestroyObject(Cube obj)
        {
            obj.Released -= ReleaseObject;
            Destroy(obj.gameObject);
        }

        
    }
}
