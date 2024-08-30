using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMover : MonoBehaviour
{
    private Vector3 _velocity;

    public void Init(Vector3 velocity)
    {
        _velocity = velocity;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = _velocity;
    }
}
