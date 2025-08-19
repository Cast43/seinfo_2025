using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string StartScene;
    public void StartGame()
    {
        SceneManager.LoadScene(StartScene);
    }
}
