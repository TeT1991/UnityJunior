
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    private float _chanceToDivide;

    public event Action<bool, Cube> Divided;

    private void Start()
    {
        Init();
    }

    public void TryToDivide(Cube cube)
    {
        bool isDivided;

        if (TryGetChance())
        {
            isDivided = true;
        }
        else
        {
            isDivided = false;
        }

        Debug.Log(isDivided);

        DecreaseChancheToDivide();

        Divided?.Invoke(isDivided, cube);
    }

    private bool TryGetChance()
    {
        float minPercent = 0;
        float maxPercent = 100;
        float chance = UnityEngine.Random.Range(minPercent, maxPercent);

        return chance <= _chanceToDivide;
    }

    private void DecreaseChancheToDivide()
    {
        float divider = 2;
        _chanceToDivide /= divider;
    }

    private void Init()
    {
        _chanceToDivide = 100;
    }
}
