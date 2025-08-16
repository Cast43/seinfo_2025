using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentLife;
    public int maxLife;
    void Start()
    {
        currentLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        currentLife--;
        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }


}
