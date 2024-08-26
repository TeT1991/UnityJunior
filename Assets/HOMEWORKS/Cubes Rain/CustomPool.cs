using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubesRain
{
    public class CustomPool : MonoBehaviour
    {
        [SerializeField] private MainPlatform _paltform;

        [SerializeField] private Cube _prefab;
        [SerializeField] private int _capacity;
        [SerializeField] private int _timeToFirstLauch;
        [SerializeField] private int _delay;

        private Queue<Cube> _pool = new Queue<Cube>();

        private void Start()
        {
            InvokeRepeating(nameof(LaunchPool), _timeToFirstLauch, _delay);
        }

        private void Update()
        {
            Debug.Log(_pool.Count);
        }

        private void AddObjectToPool(Cube obj)
        {
            _pool.Enqueue(obj);
        }

        private void CreateObject()
        {
            Cube obj = Instantiate(_prefab);
            obj.transform.position = CalculateNewPosition();
            obj.Released += ReleaseObject;
            AddObjectToPool(obj);
        }

        private void LaunchPool()
        {
            if(_pool.Count < _capacity)
            {
                CreateObject();
            }
            else
            {
                GetObject();
            }
        }

        private void GetObject()
        {
            Cube obj = _pool.Dequeue();

            obj.transform.position = CalculateNewPosition();
            obj.gameObject.SetActive(true);
        }

        private void ReleaseObject(Cube obj)
        {
            obj.gameObject.SetActive(false);

            TryReturnToPool(obj);
        }

        private void TryReturnToPool(Cube obj)
        {
            if(_pool.Count < _capacity)
            {
                _pool.Enqueue(obj);
            }
            else
            {
                DestroyObject(obj);
            }
        }

        private void DestroyObject(Cube obj)
        {
            Debug.Log("DESTORY");
            obj.Released -= ReleaseObject;
            Destroy(obj.gameObject);
        }

        private Vector3 CalculateNewPosition()
        {
            float minValue = -5;
            float maxValue = 5;

            float x = Random.Range(minValue, maxValue);
            float y = transform.position.y;
            float z = Random.Range(minValue, maxValue);

            return new Vector3(x, y, z);
        }
    }
}
