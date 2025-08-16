using UnityEngine;

public class PlayerFeetDamage : MonoBehaviour
{
    public int damage;
    void Start()
    {
        // rig = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log($"pe do player: {other.name}");
            // rig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse); // ajuste a força conforme necessário

            var health = other.GetComponent<Health>();
            if (health != null) health.TakeDamage(damage);
        }
    }
}
