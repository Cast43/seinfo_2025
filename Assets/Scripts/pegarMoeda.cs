using UnityEngine;

public class Moeda : MonoBehaviour
{
    [Header("Valor da Moeda")]
    public int valorDaMoeda = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(valorDaMoeda);
            Destroy(gameObject);
        }
    }
}