using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Text scoreField;
    public Text lifeField;
    public Text totalLifesField;
    public PlayerController playerCont;

    void Update()
    {
        if(lifeField != null)
        {
            lifeField.text = $"Life \nX{playerCont.life.ToString()}";
        }


        scoreField.text = $"Score \nX{GameManager.instance.score.ToString()}";
        totalLifesField.text = $"Total Lifes \nX{GameManager.instance.currentLifes.ToString()}";
    }
}
