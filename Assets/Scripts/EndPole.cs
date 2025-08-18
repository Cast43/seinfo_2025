using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPole : MonoBehaviour
{
    public string nextSceneName;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
