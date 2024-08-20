using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _standartRadius;
    [SerializeField] private float _standartForce;

    private Divider _divider;

    private void Start()
    {
        Init();
    }

    private void TryExplode(bool isDivided, Cube cube)
    {
        if (isDivided == false)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(cube.transform.position, CalculateRadius(cube));

            foreach (Collider2D collider in colliders)
            {
                Vector2 direction = collider.transform.position - cube.transform.position;

                if (collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
                {
                    rigidbody2D.AddForce(direction * CalculateForce(cube, collider.transform.position), ForceMode2D.Impulse);
                }
                else
                {
                    return;
                }
            }
        }
    }

    private float CalculateRadius(Cube cube)
    {
        float minValue = 0;
        float radiusModifier = Mathf.InverseLerp(_standartRadius, minValue, cube.transform.localScale.x);

        return _standartRadius + (_standartRadius - (_standartRadius * radiusModifier));  
    }

    private float CalculateForce(Cube cube, Vector2 target)
    {
        float minValue = 0;
        float distance = Vector2.Distance(cube.transform.position, target);

        float forceModifierByDistance = Mathf.InverseLerp(CalculateRadius(cube), minValue, distance);

        return _standartForce + (_standartForce * forceModifierByDistance);
    }

    private void Init()
    {
        while (_divider == null)
        {
            _divider = GetComponent<Divider>();
        }

        _divider.Divided += TryExplode;
    }
}
