using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    public GameObject effect;
    public float yOffset;
    public Animator anim;
    public bool used = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.transform.position.y < transform.position.y - 1)
            {
                if (used) return;
                used = true;
                anim.SetBool("Used", true);
                Vector3 upPosition = transform.position + new Vector3(0, yOffset);
                Instantiate(effect, upPosition, Quaternion.identity);
            }

        }
    }
}
