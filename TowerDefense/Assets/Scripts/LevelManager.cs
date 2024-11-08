using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main; // Inst�ncia est�tica para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform come�o; // Onde aparece o inimigo
    public GameObject prefabInimigo; // Prefab do inimigo
    public int quantidadeInimigos = 5; // Quantidade de inimigos a serem instanciados

    private void Awake()
    {
        main = this; // Define a inst�ncia do LevelManager
    }
    private void Start()
    {
        InstanciarInimigos(quantidadeInimigos); // Chama o m�todo para instanciar inimigos
    }
    // M�todo para instanciar inimigos
    public void InstanciarInimigos(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            // Calcula a posi��o de spawn com base na dist�ncia
            Vector3 posicaoSpawn = come�o.position + new Vector3(i * 1f, 0, 0);
            GameObject novoInimigo = Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);

            // Configura o objetivo inicial para o inimigo instanciado
            InimigoPai inimigoScript = novoInimigo.GetComponent<InimigoPai>();
            inimigoScript.AtualizarObjetivo(); // Define o primeiro objetivo
        }
    }
}
