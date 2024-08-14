using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterButton : MonoBehaviour
{
    private Counter _counter;
    private CounterView _counterView;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        while(_counter == null)
        {
            _counter = FindAnyObjectByType<Counter>();
        }

        while (_counterView == null)
        {
            _counterView = FindAnyObjectByType<CounterView>();
        }
    }
}
