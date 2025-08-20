using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int life;
    public float moveInput;
    public float speed;
    public float jumpImpulse;
    public float waitToDie = 1.5f;
    // public bool isJumping;
    public bool dieying = false;
    public Rigidbody2D rig;
    public Collider2D jumpCollider;
    public LayerMask jumpFilter;
    public Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("Dieying", dieying);
        anim.SetFloat("Speed", ((uint)rig.linearVelocityX));

        if (rig.linearVelocityY > 0)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Jump", true);
        }
        else if (rig.linearVelocityY < 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }
        if (life <= 0)
        {
            if (dieying == false)
            {
                dieying = true;
                GameManager.instance.currentLifes--;
                rig.linearVelocityY += 50;
            }
            if (waitToDie > 0)
            {
                waitToDie -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            //alterar
            if (moveInput < 0)
            {
                if (transform.localScale.x > 0)
                {
                    Vector3 newScale = transform.localScale;
                    newScale.x = -transform.localScale.x;
                    transform.localScale = newScale;
                }
            }
            else
            {
                if (transform.localScale.x < 0)
                {
                    Vector3 newScale = transform.localScale;
                    newScale.x = -transform.localScale.x;
                    transform.localScale = newScale;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (dieying) return;

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
            anim.SetTrigger("Damaged");
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
    }
}
