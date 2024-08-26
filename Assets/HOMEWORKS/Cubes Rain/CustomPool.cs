using System.Collections.Generic;
using UnityEngine;

namespace CubesRain
{
    [RequireComponent(typeof(ObjectsCreator))]
    public class CustomPool : MonoBehaviour
    {
        [SerializeField] private MainPlatform _paltform;

        [SerializeField] private int _capacity;
        [SerializeField] private int _timeToFirstLauch;
        [SerializeField] private int _delay;

        private ObjectsCreator _objectsCreator;

        private Queue<Cube> _pool = new Queue<Cube>();

        private void Awake()
        {
            _objectsCreator = GetComponent<ObjectsCreator>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(LaunchPool), _timeToFirstLauch, _delay);
        }

        private void AddObjectToPool(Cube obj)
        {
            _pool.Enqueue(obj);
        }

        private void LaunchPool()
        {
            if(_pool.Count == 0)
            {
                CreateObject();
            }
            else
            {
                GetObject();
            }

            Debug.Log(_pool.Count);
        }

        private void GetObject()
        {
            Cube obj = _pool.Dequeue();
            obj.transform.position = CalculateNewPosition();
            obj.Reset();
            obj.gameObject.SetActive(true);
        }

        private void ReleaseObject(Cube obj)
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

        private void CreateObject()
        {
            Cube obj = _objectsCreator.CreateObject(CalculateNewPosition());
            obj.Released += ReleaseObject;
            AddObjectToPool(obj);
            GetObject();
        }

        private void DestroyObject(Cube obj)
        {
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
