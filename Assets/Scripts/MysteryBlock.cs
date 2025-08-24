using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    public GameObject effect;
    public float yOffset;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector3 upPosition = transform.position + new Vector3(0, yOffset);
            // Instantiate(effect, transform.);
        }
    }
}
