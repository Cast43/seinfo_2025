using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float moveInput = 1;
    public Rigidbody2D rig;
    public Collider2D groundCollider;
    public LayerMask groundFilter;
    public int damage;
    public float deathImpulse = 20;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rig.linearVelocity;
        velocity.x = moveInput * speed;
        rig.linearVelocity = velocity;

        if (!groundCollider.IsTouchingLayers(groundFilter))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            moveInput *= -1;

            // Debug.Log("trocaLado");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // só o Player ativa
        {
            Rigidbody2D colliderRig = collision.GetComponent<Rigidbody2D>();
            if (colliderRig != null)
            {
                // colliderRig.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário
                colliderRig.linearVelocity = new Vector2(colliderRig.linearVelocity.x, deathImpulse); // "quicar"
                var health = GetComponent<Health>();
                if (health != null) health.TakeDamage(damage);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log($"cabeça inimigo: {collision.collider.name}");
            var health = collision.collider.GetComponent<Health>();
            if (health != null) health.TakeDamage(damage);
        }
    }
}
