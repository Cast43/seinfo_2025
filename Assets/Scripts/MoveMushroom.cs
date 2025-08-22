using UnityEngine;

public class MoveMushroom : MonoBehaviour
{
    public int randomSide;
    public float speed;
    public Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        randomSide = Random.Range(0, 1);
    }

    void FixedUpdate()
    {
        if (randomSide == 0)
        {
            rig.linearVelocityX = speed;
        }
        else
        {
            rig.linearVelocityX = -speed;
        }
    }
}
