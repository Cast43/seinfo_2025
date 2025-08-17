using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (gameObject.name == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Destroy(gameObject);
        }
    }


}
