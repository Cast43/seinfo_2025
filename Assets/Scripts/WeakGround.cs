using UnityEngine;

public class WeakGround : MonoBehaviour
{
    public float timeToDestroy = 3f;
    public float countTimeToDestroy = 0f;
    public float timeToRestore = 3f;
    public float countTimeToRestore = 0f;
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
                GetComponent<SpriteRenderer>().enabled = false;
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
            GetComponent<SpriteRenderer>().enabled = true;

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
