using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    public Transform pontoDeSpawn; // Ponto onde os inimigos ser�o instanciados
    public int quantidadeDeInimigosParaSpawn = 18; // Quantidade de inimigos a serem instanciados
    public static LevelManager main; // Inst�ncia est�tica para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform come�o; // Onde aparece o inimigo
    public GameObject prefabInimigo; // Prefab do inimigo
    public int quantidadeInimigos = 5; // Quantidade de inimigos a serem instanciados
    public int ContadorDeColisao;
    public int MaximoDeColisao = 10;
    public GameObject gameOverUI; // Refer�ncia � UI de Game Over.
    private int score = 0; // Pontua��o atual
    public TextMeshProUGUI scoreText; // Refer�ncia ao elemento de texto na UI


    [SerializeField]
    private List<GameObject> ListaDeInimigosPrefab; // Lista de prefabs dos inimigos

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        InstanciarInimigosAleatorios();
        UpdateScoreText(); // Atualiza o texto ao iniciar
    }

    void InstanciarInimigosAleatorios()
    {
        for (int i = 0; i < quantidadeDeInimigosParaSpawn; i++)
        {
            // Escolhe um inimigo aleat�rio da lista
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
        // Aqui voc� pode adicionar l�gica adicional, como reiniciar o jogo ou voltar ao menu
        Time.timeScale = 0; // Pausa o jogo
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Pausa o jogo.
    }

    public void SeMorrerAparece()
    {
        
            ShowOptions options = new ShowOptions();
            Advertisement.Show("Rewarded_Ad", options);
            // Adicione l�gica ap�s o an�ncio ser exibido
            // Voc� pode usar um m�todo separado para lidar com o resultado do an�ncio
       
    }

    // M�todo para lidar com o resultado do an�ncio
    public void HandleAdResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Continua��o concedida ap�s assistir ao an�ncio.");
            gameOverUI.SetActive(false);
            Time.timeScale = 1; // Retoma o jogo.
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.Log("An�ncio pulado, continua��o n�o concedida.");
        }
        else
        {
            Debug.LogError("Erro ao exibir o an�ncio de continua��o.");
        }
    }
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText(); // Atualiza o texto sempre que os pontos mudarem
    }

    // Atualiza o texto na tela
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
