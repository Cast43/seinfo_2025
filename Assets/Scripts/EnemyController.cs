using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life;
    public float speed;
    public float moveInput = 1;
    public Rigidbody2D rig;
    // public Collider2D groundCollider;
    public LayerMask groundFilter;
    public LayerMask wallFilter;
    public Transform checkPoint1;
    public Transform checkPoint2;
    public int damage;
    public float deathImpulse = 20;
    public int point = 20;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (life <= 0)
        {
            GameManager.instance.AddScore(point);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rig.linearVelocity;
        velocity.x = moveInput * speed;
        rig.linearVelocity = velocity;

        bool isCollidingGround = Physics2D.Linecast(checkPoint1.position, checkPoint2.position, groundFilter);
        bool isCollidingWall = Physics2D.Linecast(checkPoint1.position, checkPoint2.position, wallFilter);
        if (!isCollidingGround || isCollidingWall)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            moveInput *= -1;
            // Debug.Log("trocaLado");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) // só o Player ativa
        {
            if (collider.transform.position.y > transform.position.y + 0.2f)
            {
                Rigidbody2D colliderRig = collider.GetComponent<Rigidbody2D>();
                if (colliderRig != null)
                {
                    Debug.Log("acertou");
                    // colliderRig.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário
                    colliderRig.linearVelocity = new Vector2(colliderRig.linearVelocity.x, deathImpulse); // "quicar"
                    life--;
                    // var health = GetComponent<Health>();
                    // if (health != null) health.TakeDamage(damage);
                }
            }
        }
    }
}
