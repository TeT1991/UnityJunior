using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Material _material;

    private void Start()
    {
        Init();
        ChangeColor();
    }

    private void ChangeColor()
    {
        Color color = Random.ColorHSV();
        color.a = 1;

        _material.color = color;
    }

    private void Init()
    {
        _material = GetComponent<Renderer>().material;
    }
}
