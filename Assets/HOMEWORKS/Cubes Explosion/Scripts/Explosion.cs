using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Explosion : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Spawner _spawner;

    [SerializeField] private float _maxPower;
    [SerializeField] private float _maxRadius;

    private void Start()
    {
        Init();
    }

    public void Explode()
    {
        Debug.Log("Explode");
        float radius = CalculateExplosionRadius();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rigidbody2D = collider.GetComponent<Rigidbody2D>();

            Vector2 direction = collider.transform.position - transform.position;
            Vector2 force = direction * CalculateExplosionPower(radius, collider.transform.position);

            rigidbody2D.AddForce(direction * CalculateExplosionPower(radius, collider.transform.position), ForceMode2D.Impulse);

            Debug.Log($"{collider.name} --- {force}");
        }
    }

    private float CalculatePercent(float value, float maxValue)
    {
        int minValue = 0;

        return Mathf.InverseLerp(minValue, maxValue, value);
    }

    private float CalculateExplosionRadius()
    {
        float minRadius = 1;
        float modifier = 2f;

        float radius;

        if (_maxRadius < transform.localScale.x)
        {
            radius = minRadius;

            return radius;
        }

        float tempRadius = transform.localScale.x * modifier;

        radius = _maxRadius - (tempRadius * CalculatePercent(tempRadius, _maxRadius));

        if (radius > _maxRadius)
        {
            radius = _maxRadius;
        }

        return radius;
    }

    private float CalculateExplosionPower(float radius, Vector2 targetPosition)
    {
        float distance = Vector2.Distance(transform.position, targetPosition);

        float power = _maxPower + (_maxPower * CalculatePercent(radius, distance));

        return power;
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _maxRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, CalculateExplosionRadius());
    }
}
