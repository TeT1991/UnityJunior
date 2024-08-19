using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Divider : MonoBehaviour
{
    private float _maxChanceToDivide;

    public UnityEvent Divided;
    public UnityEvent NotDivided;

    private void Start()
    {
        Init();
    }

    public void TryDivide()
    {
        int maxPercent = 100;
        int minPercent = 0;
        float percent = Random.Range(minPercent, maxPercent);
        Debug.Log(percent + "   " + _maxChanceToDivide);

        if (percent <= _maxChanceToDivide)
        {
            Divided?.Invoke();
        }
        else
        {
            NotDivided?.Invoke();
        }

        CalculateNewChancePercent();
    }

    private void CalculateNewChancePercent()
    {
        int divider = 2;
        _maxChanceToDivide /= divider;
    }

    private void Init()
    {
        _maxChanceToDivide = 100;
    }
}
