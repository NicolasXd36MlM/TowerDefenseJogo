using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


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
            int indiceAleatorio = Random.Range(1, ListaDeInimigosPrefab.Count);
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

}
