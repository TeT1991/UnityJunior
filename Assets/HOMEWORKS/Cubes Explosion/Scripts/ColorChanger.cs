using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        Color color = Random.ColorHSV();
        color.a = 1;

        _spriteRenderer.color = color;
    }
}
