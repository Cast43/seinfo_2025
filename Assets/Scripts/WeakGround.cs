using UnityEngine;

public class WeakGround : MonoBehaviour
{
    public float timeToDestroy = 3f;
    public float countTimeToDestroy = 0f;
    public float timeToRestore = 3f;
    public float countTimeToRestore = 0f;
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;
    public SpriteRenderer sprite3;
    void Start()
    {
        // countTimeToDestroy = timeToDestroy;
    }

    void Update()
    {
        if (countTimeToRestore > 0)
        {
            if (countTimeToDestroy <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                sprite1.enabled = false;
                sprite2.enabled = false;
                sprite3.enabled = false;
                countTimeToRestore -= Time.deltaTime;
            }
            else
            {
                countTimeToDestroy -= Time.deltaTime;
            }
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            sprite1.enabled = true;
            sprite2.enabled = true;
            sprite3.enabled = true;

        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (countTimeToRestore <= 0)
            {
                countTimeToDestroy = timeToDestroy;
                countTimeToRestore = timeToRestore;
            }
        }
    }
}
