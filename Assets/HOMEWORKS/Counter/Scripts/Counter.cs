using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;

    private bool _isStarted;
    private float _delay;
    private int _value;

    private Coroutine _coroutine;

    public event Action<int> ValueChanged;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeStatus);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void ChangeStatus()
    {
        _isStarted = !_isStarted; 

        if (_isStarted)
        {
            _coroutine = StartCoroutine(ChangeValue(_delay));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator ChangeValue(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            IncreaseValue();
            yield return wait;
        }
    }

    private void IncreaseValue()
    {
        _value++;
        Debug.Log(_value.ToString());

        ValueChanged.Invoke(_value);
    }

    private void Init()
    {
        _isStarted = false;
        _delay = 0.5f;
        _value = 0;
    }
}
