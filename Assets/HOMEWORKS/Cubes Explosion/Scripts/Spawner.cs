
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Divider))]
public class Spawner : MonoBehaviour
{
    private Divider _divider;

    private int _spawnCountMin;
    private int _spawnCountMax;

    private Vector2 _scale;

    [SerializeField] private Cube _prefabToSpawn;

    private void OnEnable()
    {
        Init();
        _divider.Divided.AddListener(CreateCubes);
    }

    private void OnDestroy()
    {
        _divider.Divided.RemoveListener(CreateCubes);
    }

    private void Start()
    {
        CreateCubes();
    }

    private void Init()
    {
        _spawnCountMin = 2;
        _spawnCountMax = 6;

        while (_divider == null)
        {
            _divider = GetComponent<Divider>();
        }

        ResetScale();
    }

    private void CreateCubes()
    {
        int spawnCount = Random.Range(_spawnCountMin, _spawnCountMax);

        int count = 0;

        for (int i = 0; i < spawnCount; i++)
        {
            var spawnedCube = Instantiate(_prefabToSpawn);

            SpriteRenderer spriteRenderer = spawnedCube.GetComponentInChildren<SpriteRenderer>();
            Cube cube = spawnedCube.GetComponentInChildren<Cube>();

            spawnedCube.transform.position = CalculateSpawnPoint();
            spawnedCube.transform.localScale = CalculateScale(count);
            spriteRenderer.color = CalculateColor();

            count++;
        }

        ResetScale();
    }

    private Vector2 CalculateSpawnPoint()
    {
        Camera camera = Camera.main;

        float spawnPointX = Random.Range(0, Screen.width);
        float spawnPointY = Random.Range(0, Screen.height);

        return camera.ScreenToWorldPoint(new Vector2(spawnPointX, spawnPointY));
    }

    private Vector2 CalculateScale(int count)
    {
        int multiplyer = 2;
        int divider = count * multiplyer;

        if (divider > 0)
        {
            _scale /= divider;
        }

        return _scale;
    }

    private void ResetScale()

    {
        _scale = Vector2.one;
    }

    private Color CalculateColor()
    {
        float alpha = 1f;
        Color color = Random.ColorHSV();
        color.a = alpha;

        return color;
    }
}
