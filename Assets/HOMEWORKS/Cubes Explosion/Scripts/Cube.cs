using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Clicked;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }
}
