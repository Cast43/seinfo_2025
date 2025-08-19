using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int life;
    public float moveInput;
    public float speed;
    public float jumpImpulse;
    public bool isJumping;
    public Rigidbody2D rig;
    public Collider2D jumpCollider;
    public LayerMask jumpFilter;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (life <= 0)
        {
            GameManager.instance.currentLifes--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rig.linearVelocity;
        velocity.x = moveInput * speed;

        if (Input.GetButton("Jump"))
        {
            if (velocity.y <= 0)
            {
                if (jumpCollider.IsTouchingLayers(jumpFilter))
                {
                    velocity.y = jumpImpulse;

                    // Debug.Log("pulo");
                    // rig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário
                }
            }
        }
        else
        {
            if (velocity.y > 0)
            {
                Debug.Log("release");
                velocity.y *= 0.5f;
            }
        }
        rig.linearVelocity = velocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Vector2 pushDirection = transform.position - collision.transform.position;
            rig.linearVelocity = 20 * pushDirection.normalized;
            life--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("InstaDie"))
        {
            life -= life;
        }
        //     if (collider.CompareTag("Enemy")) // só o Player ativa
        //     {
        //         if (collider.transform.position.y > transform.position.y - 0.2f)
        //         {
        //             // Rigidbody2D colliderRig = collider.GetComponent<Rigidbody2D>();
        //             if (rig != null)
        //             {
        //                 Debug.Log("acertou");
        //                 // colliderRig.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário
        //                 rig.linearVelocity = new Vector2(rig.linearVelocity.x, 30); // "quicar"
        //                 life--;
        //                 // var health = GetComponent<Health>();
        //                 // if (health != null) health.TakeDamage(damage);
        //             }
        //         }
        //     }
    }
}
