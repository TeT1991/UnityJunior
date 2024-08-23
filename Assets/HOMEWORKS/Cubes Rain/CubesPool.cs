using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace CubesRain
{
    public class CubesPool : MonoBehaviour
    {
        [SerializeField] private Cube _prefab;
        [SerializeField] private MainPlatform _platform;

        private ObjectPool<Cube> _pool;
        private float _repeatRate = 1f;
        private int _poolCapacity = 2;
        private int _poolMaxSize = 2;

        private Vector3 _startPoint;

        private void Awake()
        {
            _pool = new ObjectPool<Cube>(
                createFunc: () => Instantiate(_prefab, CalculateRandomSpawnPosition(), Quaternion.identity),
                actionOnGet: (obj) => ActionOnGet(obj),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => DeleteFromPool(obj),
                collectionCheck: false,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize);
        }

        private void Update()
        {
            Debug.Log(_pool.CountAll);
        }

        private void Start()
        {
            InvokeRepeating(nameof(GetCube), 0, 0.3f);
        }

        private void GetCube()
        {
            _pool.Get();
        }

        private void ActionOnGet(Cube cube) //когда берем из пула
        {
            cube.Reset();
            cube.transform.SetPositionAndRotation(CalculateRandomSpawnPosition(), Quaternion.Euler(CalculateRandomRotation()));

            cube.GetComponent<Rigidbody>().velocity = Vector3.zero;

            cube.gameObject.SetActive(true);
            cube.CollidedFirstTime += ReleasePool;
        }

        private void ReleasePool(Cube cube)
        {
            cube.CollidedFirstTime -= ReleasePool;
            _pool.Release(cube);
        }

        private void DeleteFromPool(Cube cube)
        {
            cube.CollidedFirstTime -= ReleasePool;
            Destoryer.Destroy(cube.gameObject);
        }

        private Vector3 CalculateRandomSpawnPosition()
        {
            float divider = 2;


            float xPoisition = Random.Range((Vector3.zero.x - _platform.gameObject.transform.localScale.x/divider), (Vector3.zero.x + _platform.gameObject.transform.localScale.x/divider));
            float yPosition = transform.position.y;
            float zPoisition = Random.Range((Vector3.zero.z - _platform.gameObject.transform.localScale.z/divider), (Vector3.zero.z + _platform.gameObject.transform.localScale.z/divider));

            return new Vector3(xPoisition, yPosition, zPoisition);
        }

        private Vector3 CalculateRandomRotation()
        {
            float minAngle = 0;
            float maxAngle = 360;

            float xRotation = Random.Range(minAngle, maxAngle);
            float yRotation = Random.Range(minAngle, maxAngle);
            float zRotation = Random.Range(minAngle, maxAngle);

            return new Vector3(xRotation, yRotation, zRotation);
        }
    }
}

