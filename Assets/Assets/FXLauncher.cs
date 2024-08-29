using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXLauncher : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnMouseUpAsButton()
    {
        Instantiate(_particleSystem);
        Destroy(gameObject);
    }
}
