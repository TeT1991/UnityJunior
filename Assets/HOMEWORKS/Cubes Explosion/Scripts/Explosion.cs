using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _standartRadius;
    [SerializeField] private float _standartForce;

    private Rigidbody _rigidBody;

    private void Start()
    {
        Init();
    }

    public void Explode()
    {
        float radius = CalculateRadius();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _standartRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                float minDistance = 0;
                float distance = Vector3.Distance(transform.position, rigidbody.position);
                float modifierByDistance = CalculateModifier(minDistance, radius, distance);
                float force = (_standartForce + CalculateForce()) * modifierByDistance ;

                rigidbody.AddExplosionForce(force, transform.position, _standartRadius);
            }
        }
    }

    private float CalculateModifier(float minValue, float maxValue, float value)
    {
        return Mathf.InverseLerp(maxValue, minValue, value);
    }

    private float CalculateRadius()
    {
        float minSize = 0;
        float maxSize = 1;
        float minModifier = 0.1f;

        float modifierByScale = CalculateModifier(minSize, maxSize, transform.localScale.x);
        
        if(modifierByScale <= 0)
        {
            modifierByScale = minModifier;
        }

        float radius = _standartRadius + (_standartRadius * modifierByScale);

        return radius;
    }

    private float CalculateForce()
    {
        float minSize = 0;
        float maxSize = 1;
        float minModifier = 0.1f;

        float modifierByScale = CalculateModifier(minSize, maxSize, transform.localScale.x);

        if (modifierByScale <= 0)
        {
            modifierByScale = minModifier;
        }

        float force = _standartForce + (_standartForce * modifierByScale);

        return force;
    }

    private void Init()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, CalculateRadius());
    }
}
