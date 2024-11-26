using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;

public class LevelManager : MonoBehaviour
{
    public Transform pontoDeSpawn; // Ponto onde os inimigos serão instanciados
    public int quantidadeDeInimigosParaSpawn = 18; // Quantidade de inimigos a serem instanciados
    public static LevelManager main; // Instância estática para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform começo; // Onde aparece o inimigo
    public GameObject prefabInimigo; // Prefab do inimigo
    public int quantidadeInimigos = 5; // Quantidade de inimigos a serem instanciados
    public int ContadorDeColisao;
    public int MaximoDeColisao = 10;
    public GameObject gameOverUI; // Referência à UI de Game Over.

    [SerializeField]
    private List<GameObject> ListaDeInimigosPrefab; // Lista de prefabs dos inimigos

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        InstanciarInimigosAleatorios();
    }

    void InstanciarInimigosAleatorios()
    {
        for (int i = 0; i < quantidadeDeInimigosParaSpawn; i++)
        {
            // Escolhe um inimigo aleatório da lista
            int indiceAleatorio = Random.Range(0, ListaDeInimigosPrefab.Count); // Corrigido para incluir o 0
            GameObject inimigoPrefab = ListaDeInimigosPrefab[indiceAleatorio];

            // Instancia o inimigo no ponto de spawn
            Instantiate(inimigoPrefab, pontoDeSpawn.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Final"))
        {
            ContadorDeColisao++;

            if (ContadorDeColisao >= MaximoDeColisao)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Aqui você pode adicionar lógica adicional, como reiniciar o jogo ou voltar ao menu
        Time.timeScale = 0; // Pausa o jogo
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Pausa o jogo.
    }

    public void SeMorrerAparece()
    {
        if (Advertisement.GetPlacementState("Rewarded_Ad") == PlacementState.Ready)
        {
            ShowOptions options = new ShowOptions();
            Advertisement.Show("Rewarded_Ad", options);
            // Adicione lógica após o anúncio ser exibido
            // Você pode usar um método separado para lidar com o resultado do anúncio
        }
        else
        {
            Debug.LogWarning("Anúncio recompensado não está pronto para continuar.");
        }
    }

    // Método para lidar com o resultado do anúncio
    public void HandleAdResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Continuação concedida após assistir ao anúncio.");
            gameOverUI.SetActive(false);
            Time.timeScale = 1; // Retoma o jogo.
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.Log("Anúncio pulado, continuação não concedida.");
        }
        else
        {
            Debug.LogError("Erro ao exibir o anúncio de continuação.");
        }
    }
}
