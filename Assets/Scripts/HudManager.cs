using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Text scoreField;
    public Text lifeField;

    void Update()
    {
        scoreField.text = $"Score \nX{GameManager.instance.score.ToString()}";
        lifeField.text = $"Mario \nX{GameManager.instance.currentLifes.ToString()}";
    }
}
