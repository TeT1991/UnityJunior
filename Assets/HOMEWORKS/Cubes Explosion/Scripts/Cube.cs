using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Cube : MonoBehaviour
{
    private Explosion _explosion;
    private float _chanceToDivide;
    private bool _isDivided;

    public event Action<Cube> Clicked;

    public float ChanceToDivide => _chanceToDivide;

    public bool IsDivided => _isDivided;

    public Explosion ExplosionComponent => _explosion;

    private void Start()
    {
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }

    public void HasDivided()
    {
        float minPercent = 0;
        float maxPercent = 100;
        float chance = UnityEngine.Random.Range(minPercent, maxPercent);

        if (chance <= _chanceToDivide)
        {
            _isDivided = true;
        }
    }

    public void SetChanceToDivide(float value)
    {
        if (value >= 0 && value <= 100)
        {
            _chanceToDivide = value;
        }

        HasDivided();
    }

    public void Explode()
    {
        _explosion.Explode();
    }
}
