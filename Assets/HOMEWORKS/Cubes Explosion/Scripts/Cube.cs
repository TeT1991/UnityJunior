using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cube : MonoBehaviour
{
    //private Rigidbody2D _rigidBody;

    public event Action<Cube> Clicked;

    //public Rigidbody2D GetRigidBody()
    //{
    //    return _rigidBody;
    //}

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }

    //private void Init()
    //{
    //    while(_rigidBody == null)
    //    {
    //        _rigidBody = GetComponent<Rigidbody2D>();
    //    }
    //}
}
