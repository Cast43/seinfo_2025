using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float waitToRestart;
    public int currentLifes;
    public int startLifes;
    public int score;
    public GameObject loseScreen;
    public string startScene;
    public static GameManager instance;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentLifes = startLifes;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (currentLifes <= 0)
        {
            RestartGame();
            // loseScreen.SetActive(true);
        }
    }
    public void AddScore(int Points)
    {
        score += Points;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(startScene);
        // loseScreen.SetActive(false);
        // Destroy(gameObject);
        currentLifes = startLifes;
        score = 0;
    }
}
