using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main; // Instância estática para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform começo; // Onde aparece o inimigo
    public GameObject prefabInimigo; // Prefab do inimigo
    public int quantidadeInimigos = 5; // Quantidade de inimigos a serem instanciados

    private void Awake()
    {
        main = this; // Define a instância do LevelManager
    }
    private void Start()
    {
        InstanciarInimigos(quantidadeInimigos); // Chama o método para instanciar inimigos
    }
    // Método para instanciar inimigos
    public void InstanciarInimigos(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            // Calcula a posição de spawn com base na distância
            Vector3 posicaoSpawn = começo.position + new Vector3(i * 1f, 0, 0);
            GameObject novoInimigo = Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);

            // Configura o objetivo inicial para o inimigo instanciado
            InimigoPai inimigoScript = novoInimigo.GetComponent<InimigoPai>();
            inimigoScript.AtualizarObjetivo(); // Define o primeiro objetivo
        }
    }
}
