using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ClickHandler))]
public class Explosion : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private ClickHandler _clickHandler;

    [SerializeField] private float _power;

    private void Start()
    {
        Init();
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, CalculateExplosionRadius());

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rigidbody2D = collider.GetComponent<Rigidbody2D>();

            Vector2 direction = collider.transform.position - transform.position;

            rigidbody2D.AddForce(direction * _power, ForceMode2D.Impulse);
        }
    }

    private float CalculateExplosionRadius()
    {
        float modifier = 4f;
        return transform.localScale.x * modifier;
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _clickHandler = GetComponent<ClickHandler>();

        _clickHandler.Clicked.AddListener(Explode);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,CalculateExplosionRadius());
    }
}
