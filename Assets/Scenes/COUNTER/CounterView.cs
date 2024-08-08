using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _counter.OnChanged.AddListener(Display);
    }

    private void OnDisable()
    {
        _counter.OnChanged.RemoveAllListeners();
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
