using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
   
    public Transform pontoDeSpawn; // Ponto onde os inimigos ser�o instanciados
    public int quantidadeDeInimigosParaSpawn = 18; // Quantidade de inimigos a serem instanciados
    public static LevelManager main; // Inst�ncia est�tica para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform come�o; // Onde aparece o inimigo
    public GameObject prefabInimigo; // Prefab do inimigo
    public int quantidadeInimigos = 5; // Quantidade de inimigos a serem instanciados

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
            // Escolhe um inimigo aleat�rio da lista
            int indiceAleatorio = Random.Range(1, ListaDeInimigosPrefab.Count);
            GameObject inimigoPrefab = ListaDeInimigosPrefab[indiceAleatorio];

            // Instancia o inimigo no ponto de spawn
            Instantiate(inimigoPrefab, pontoDeSpawn.position, Quaternion.identity);
        }
    }
    

}
