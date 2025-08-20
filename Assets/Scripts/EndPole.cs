using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPole : MonoBehaviour
{
    public bool goingUp = true;
    public Transform maxUp;
    public Transform maxDown;
    public GameObject bar;
    public int scoreValue;
    public float barVelocity;
    public string nextSceneName;
    void Update()
    {
        if (goingUp)
        {
            bar.transform.position += new Vector3(0, (barVelocity * Time.deltaTime));
            if (bar.transform.position.y > maxUp.position.y)
            {
                goingUp = false;
            }
        }
        else
        {
            bar.transform.position -= new Vector3(0, (barVelocity * Time.deltaTime));
            if (bar.transform.position.y < maxDown.position.y)
            {
                goingUp = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            int score = (int)(bar.transform.position.y - maxDown.position.y) * scoreValue;
            Debug.Log((bar.transform.position.y - maxDown.position.y));
            GameManager.instance.AddScore(score);
            SceneManager.LoadScene(nextSceneName);

        }
    }
}
