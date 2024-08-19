using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Explosion))]
public class Cube : MonoBehaviour
{
    private Divider _divider;
    private Explosion _explosion;

    public UnityEvent Clicked;

    private void Start()
    {
        Init(); 
    }

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Clicked.RemoveAllListeners();
    }

    private void Init()
    {
        while (_divider == null)
        {
            _divider = FindAnyObjectByType<Divider>();
        }

        while(_explosion == null)
        {
            _explosion = GetComponent<Explosion>();
        }

        Clicked.AddListener(_divider.TryDivide);
        _divider.NotDivided.AddListener(_explosion.Explode);
    }
}
