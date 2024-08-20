using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Divider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabToSpawn;
    private Divider _divider;

    private float _scale;

    private void Start()
    {
        Init();

        bool isFirstCreate = true;

        TryCreateCubes(isFirstCreate, new Cube());
    }

    private Vector2 CalculateSpawnPoint()
    {
        float zeroPoint = 0;

        float xPoint = Random.Range(zeroPoint, Screen.width);
        float yPoint = Random.Range(zeroPoint, Screen.height);

        return Camera.main.ScreenToWorldPoint(new Vector2(xPoint, yPoint));
    }

    private void TryCreateCubes(bool isDivided, Cube cube)
    {
        if (isDivided)
        {
            int minCount = 2;
            int maxCount = 6;

            int countToSpawn = Random.Range(minCount, maxCount);

            for (int i = 0; i < countToSpawn; i++)
            {
                var spawnedCube = Instantiate(_prefabToSpawn);
                spawnedCube.transform.position = CalculateSpawnPoint();
                Vector2 scale = Vector2.one * _scale;
                spawnedCube.transform.localScale = scale;

                spawnedCube.Clicked += _divider.TryToDivide;

                CalculateScale(scale.x);
            }
        }
    }

    private void CalculateScale(float scale)
    {
        _scale = scale / 2;
    }

    private void Init()
    {
        _scale = 1;

        while (_divider == null)
        {
            _divider = GetComponent<Divider>();
        }

        _divider.Divided += TryCreateCubes;
    }
}
