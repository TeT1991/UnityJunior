using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMover : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        transform.up = direction;
    }

    public void SetVelocity(float velocity)
    {
        _rigidbody.velocity = transform.up * velocity;
    }
}
