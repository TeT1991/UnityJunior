using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public UnityEvent<int> OnChanged;

    private bool _isStarted;
    private float _timeBetweenTick;
    private int _value;

    public void ChangeStatus()
    {
        if (_isStarted == false)
        {
            _isStarted = true;
            StartCoroutine(IncreaseValue(_timeBetweenTick));
        }
        else
        {
            _isStarted = false;
            StopCoroutine(IncreaseValue(_timeBetweenTick));
        }
    }

    private void Start()
    {
        _isStarted = true;
        _timeBetweenTick = 0.5f;
        _value = 0;

        StartCoroutine(IncreaseValue(_timeBetweenTick));
    }

    private void ChangeValue()
    {
        _value++;
        OnChanged?.Invoke(_value);
    }

    private IEnumerator IncreaseValue(float time)
    {
        var wait = new WaitForSeconds(time);

        while (_isStarted)
        {
            ChangeValue();
            yield return wait;
        }
    }
}
