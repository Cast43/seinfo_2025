using UnityEngine;

public class GeradorDePlataformas : MonoBehaviour
{
    [Header("Configurações de Prefabs")] // aparece como um nome de um tópico de parâmetros
    public GameObject plataformaTerreno;
    public GameObject plataformaDesaparece;
    public GameObject Moeda;
    public GameObject endPole;
    public Transform jogadorTransform;

    [Header("Configurações de Geração")]
    public float distanciaVertical = 3.7f;
    public float variacaoHorizontal = 4f;
    public float limitePlataformas = 15;

    private float proximoY=7;
    private float chanceDePlataformaDesaparece = 0.2f;
    private float chanceDeMoeda = 0.5f;
    private float contadorDePlataformas = 0;

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
        contadorDePlataformas++;
        if(contadorDePlataformas> limitePlataformas)
        {
            return;
        }



        if (contadorDePlataformas == limitePlataformas)
        {
            geraUltimaPlataforma();
            return;
        }
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
    void geraUltimaPlataforma()
    {
        proximoY += distanciaVertical;
        float posX = Random.Range(-variacaoHorizontal, variacaoHorizontal);
        Vector3 posicaoDeGeracao = new Vector3(posX-1, proximoY, 0f);
        Instantiate(plataformaTerreno, posicaoDeGeracao, Quaternion.identity);

        Vector3 posicaoBandeira = new Vector3(posX, proximoY + 1.5f, 0f);
        Instantiate(endPole, posicaoBandeira, Quaternion.identity);
    }
}