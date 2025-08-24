using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int life = 1;
    public float moveInput;
    public float speed;
    public float jumpImpulse;
    public float waitToDie = 1.5f;
    public float timeInvulnerable = 1f;
    public float countTimeInvulnerable = 0f;
    public bool isJumping;
    public bool dieying = false;
    public Rigidbody2D rig;
    public Collider2D jumpCollider;
    public LayerMask jumpFilter;
    public Animator anim;
    public Camera cameraObj;
    public LayerMask enemyLayer;

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
        if (Input.GetButton("Jump"))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        if (life <= 0)
        {
            if (dieying == false)
            {
                dieying = true;
                GameManager.instance.currentLifes--;
                rig.linearVelocityX = 0;
                rig.linearVelocityY += 20;
                GetComponent<Collider2D>().enabled = false;
                cameraObj.transform.parent = null;
            }
            if (waitToDie > 0)
            {
                waitToDie -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);//isso está matando os inimigos e zuando a pontuação
                //resolvido
            }
        }
        else
        {
            if (countTimeInvulnerable > 0)
            {
                countTimeInvulnerable -= Time.deltaTime;
                rig.excludeLayers = enemyLayer;
                anim.SetBool("Damaged", true);
            }
            else
            {
                rig.excludeLayers = 0;
                anim.SetBool("Damaged", false);
            }
            //alterar
            if (rig.linearVelocityX < 0)
            {
                if (transform.localScale.x > 0)
                {
                    Vector3 newScale = transform.localScale;
                    newScale.x = -transform.localScale.x;
                    transform.localScale = newScale;
                }
            }
            else if (rig.linearVelocityX > 0)
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
        // if (countTimeInvulnerable > 0) return;

        moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rig.linearVelocity;
        velocity.x = moveInput * speed;


        if (isJumping)
        {
            if (velocity.y <= 0)
            {
                if (jumpCollider.IsTouchingLayers(jumpFilter))
                {
                    Debug.Log("pula");
                    velocity.y = jumpImpulse;
                }
            }
        }
        else
        {
            if (!jumpCollider.IsTouchingLayers(jumpFilter))
            {
                if (velocity.y > 0)
                {
                    velocity.y *= 0.5f;// isso diminui o valor da velocidade do koopaJump se nao estiver jumping
                }
            }
        }

        rig.linearVelocity = velocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (countTimeInvulnerable > 0) return;
            countTimeInvulnerable = timeInvulnerable;
            // anim.SetBool("Grow", false);
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            float pushForce = 10f; // ajuste a força conforme necessário

            rig.linearVelocity += new Vector2(pushDirection.x * pushForce, 0); // empurra para o lado e um pouco para cima
            // rig.linearVelocityX = 100 * pushDirection.x;
            // Debug.Log(100 * pushDirection.x); 
            life--;
        }
        if (collision.collider.CompareTag("Mushroom"))
        {
            // anim.SetBool("Grow", true);
            life++;
            Destroy(collision.gameObject);
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
