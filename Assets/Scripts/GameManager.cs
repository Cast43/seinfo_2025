using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
    public void AddScore(int Points)
    {
        score += Points;
    }
}
