using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _spawnCountMin;
    private int _spawnCountMax;

    private Vector2 _scale;

    [SerializeField] private Cube _prefabToSpawn;

    private float _chanceToSpawn;

    private void Start()
    {
        Init();

        TryCreateCubes();
    }

    private void Init()
    {
        _spawnCountMin = 2;
        _spawnCountMax = 6;
        _chanceToSpawn = 100;

        ResetScale();
    }

    private void TryCreateCubes()
    {
        if (TryGetChance())
        {
            int spawnCount = Random.Range(_spawnCountMin, _spawnCountMax);

            int count = 0;

            for (int i = 0; i < spawnCount; i++)
            {
                var spawnedCube = Instantiate(_prefabToSpawn);

                SpriteRenderer spriteRenderer = spawnedCube.GetComponentInChildren<SpriteRenderer>();
                ClickHandler clickHandler = spawnedCube.GetComponentInChildren<ClickHandler>();

                spawnedCube.transform.position = CalculateSpawnPoint();
                spawnedCube.transform.localScale = CalculateScale(count);
                spriteRenderer.color = CalculateColor();
                
                clickHandler.Clicked.AddListener(TryCreateCubes);

                count++;
            }
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
        int divider = count * 2;

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
        Color color = Random.ColorHSV();
        color.a = 1f;

        return color;
    }

    private void CalculateNewChancePercent()
    {
        int divider = 2;
        _chanceToSpawn /= divider;
    }

    private bool TryGetChance()
    {
        int maxPercent = 100;
        int minPercent = 0;
        float percent = Random.Range(minPercent, maxPercent);

        if (percent <= _chanceToSpawn)
        {
            CalculateNewChancePercent();

            return true;
        }

        CalculateNewChancePercent();

        return false;
    }
}
