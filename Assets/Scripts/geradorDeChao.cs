using UnityEngine;

public class GeradorDePlataformas : MonoBehaviour
{
    [Header("Configurações de Prefabs")] // aparece como um nome de um tópico de parâmetros
    public GameObject plataformaTerreno;
    public GameObject plataformaDesaparece;
    public GameObject Moeda;
    public Transform jogadorTransform;

    [Header("Configurações de Geração")]
    private float distanciaVertical = 3.7f;
    private float variacaoHorizontal = 4f;

    private float proximoY=7;
    private float chanceDePlataformaDesaparece = 0.2f;
    private float chanceDeMoeda = 0.5f;

    void Start()
    {
        for(int i = 0; i <= 5; i++)
        {
            GerarPlataforma();
        }
    }

    void Update()
    {
        if (jogadorTransform.position.y + 7 > proximoY)
            GerarPlataforma();
        
    }

    void GerarPlataforma()
    {
        proximoY += distanciaVertical;
        bool tipoChao = Random.value < chanceDePlataformaDesaparece;
        float viriacaoX;
        viriacaoX = variacaoHorizontal;
        if(tipoChao)
            viriacaoX -= 1f;
        
        float posX = Random.Range(-viriacaoX, viriacaoX);
        
        
        Vector3 posicaoDeGeracao = new Vector3(posX, proximoY, 0f);

        if (Random.value < chanceDePlataformaDesaparece)
        {
            Instantiate(plataformaDesaparece, posicaoDeGeracao, Quaternion.identity);
            proximoY+= 1.0f;
        }
        else
        {
            bool gerarMoeda = Random.value < chanceDeMoeda;
            Instantiate(plataformaTerreno, posicaoDeGeracao, Quaternion.identity);
            if (gerarMoeda)
            {
                Vector3 posicaoMoeda = new Vector3(posX, proximoY+1f, 0f);
                Instantiate(Moeda, posicaoMoeda, Quaternion.identity);

            }
        }

    }
}