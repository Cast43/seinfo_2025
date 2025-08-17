using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveInput;
    public float speed;
    public float jumpImpulse;
    public Rigidbody2D rig;
    public Collider2D jumpCollider;
    public LayerMask groundFilter;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rig.linearVelocity;
        velocity.x = moveInput * speed;

        if (Input.GetButton("Jump"))
        {
            if (jumpCollider.IsTouchingLayers(groundFilter))
            {
                velocity.y = jumpImpulse;

                // Debug.Log("pulo");
                // rig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário
            }
        }
        rig.linearVelocity = velocity;
    }
}
