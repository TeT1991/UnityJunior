using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;

    private bool _isStarted;
    private float _delay;
    private int _value;

    private IEnumerator _coroutine;

    public UnityEvent<int> OnChanged;

    public void ChangeStatus()
    {
        _isStarted = !_isStarted;

        switch (_isStarted)
        {
            case true:
                StartCoroutine(_coroutine);
                break;

            case false:
                StopCoroutine(_coroutine);
                break;
        }
    }

    private void Start()
    {
        Init();

        _button.onClick.AddListener(ChangeStatus);
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

        OnChanged.Invoke(_value);
    }

    private void Init()
    {
        _isStarted = false;
        _delay = 0.5f;
        _value = 0;

        _coroutine = ChangeValue(_delay);
    }

    private void OnMouseDown()
    {
        ChangeStatus();
    }
}
