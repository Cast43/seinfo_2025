using UnityEngine;

public class moveYFlorr : MonoBehaviour
{
    private float velocidadeLava = 2f;
    private float timer = 0.0f;
    public float intervaloDeAumento = 60.0f;
    public float valorDoAumento = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocidadeLava * Time.deltaTime);
        timer += Time.deltaTime;
        if(timer >= intervaloDeAumento)
        {
            velocidadeLava += valorDoAumento;
            timer = 0.0f;
        }
        
    }
}
