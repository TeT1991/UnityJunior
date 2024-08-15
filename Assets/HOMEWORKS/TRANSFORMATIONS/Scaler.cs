using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.localScale = CalculateNewVector();
    }
    private Vector3 CalculateNewVector()
    {
        float value = transform.localScale.x + _speed;
        Vector3 newVector = new Vector3(value, value, value);

        return newVector;
    }
}

