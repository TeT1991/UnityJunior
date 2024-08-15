using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _counter.ValueChanged += Display;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= Display;
    }

    private void Start()
    {
        _textMeshPro.text = "0";
    }

    private void Display(int value)
    {
        _textMeshPro.text = value.ToString();   
    }
}
