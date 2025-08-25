using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteParallax : MonoBehaviour
{
    [Tooltip("A câmera principal que segue o jogador.")]
    public Transform cameraTransform;

    [Tooltip("A velocidade do parallax. 0 = não se move, 1 = move junto com a câmera. Para fundos, use valores baixos como 0.5.")]
    [Range(0f, 1f)]
    public float parallaxFactor;

    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;

        // Tenta obter o Tilemap no próprio objeto ou nos filhos
        Tilemap tilemap = GetComponentInChildren<Tilemap>();
        if (tilemap != null)
        {
            // Comprime os limites para garantir que o tamanho seja exato ao conteúdo desenhado
            tilemap.CompressBounds(); 
            textureUnitSizeX = tilemap.localBounds.size.x * tilemap.transform.localScale.x;
        }
        else
        {
            Debug.LogError("Nenhum Tilemap encontrado nos filhos deste objeto. O efeito de parallax infinito não funcionará.");
        }
    }

    void LateUpdate()
    {
        // Calcula o quanto a câmera se moveu desde o último frame
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Move o fundo na mesma direção, mas multiplicado pelo fator de parallax
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
        
        // Atualiza a última posição da câmera para o próximo frame
        lastCameraPosition = cameraTransform.position;

        // Lógica para a repetição infinita (scrolling)
        // Se a câmera se moveu para a direita mais da metade da largura do tilemap
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x - offsetPositionX, transform.position.y);
        }
    }
}