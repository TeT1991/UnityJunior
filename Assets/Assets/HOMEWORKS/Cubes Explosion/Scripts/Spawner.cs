using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabToSpawn;
    [SerializeField] private Cube[] _initializedCubes;

    private float _chanceToSpawn;
    private float _scale;

    public event Action Spawned;

    private void Start()
    {
        _chanceToSpawn = 100;
        _scale = 1;

        PrepareInitializedCubes();
    }

    private void TryCreateCubes(Cube cube)
    {
        cube.Clicked -= TryCreateCubes;
        Spawned -= cube.Explode;

        if (cube.IsDivided)
        {
            float minCount = 2;
            float maxCount = 6;
            float count = UnityEngine.Random.Range(minCount, maxCount);

            for (int i = 0; i < count; i++)
            {
                var spawnedCube = Instantiate(_prefabToSpawn, cube.transform.position, Quaternion.identity);
                spawnedCube.Clicked += TryCreateCubes;
                spawnedCube.SetChanceToDivide(_chanceToSpawn);
                spawnedCube.transform.localScale = Vector3.one * _scale;
                Spawned += spawnedCube.Explode;
            }

            DecreaseValue(ref _chanceToSpawn);
            DecreaseValue(ref _scale);
        }
        else
        {
            Spawned?.Invoke();
        }
    }

    private void DecreaseValue(ref float value)
    {
        float divider = 2;
        value /= divider;
    }

    private void PrepareInitializedCubes()
    {
        foreach (var cube in _initializedCubes)
        {
            cube.SetChanceToDivide(_chanceToSpawn);
            cube.Clicked += TryCreateCubes;
            Spawned += cube.Explode;
        }
    }
}
