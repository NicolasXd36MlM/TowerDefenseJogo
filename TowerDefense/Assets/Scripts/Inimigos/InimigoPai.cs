using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    public float separacao = 1f;          // Distância entre inimigos
    public GameObject prefabInimigo;       // Prefab do inimigo
    public float velocidade = 5f;          // Velocidade do inimigo
    private Transform objetivo;             // Ponto de destino
    private int caminhoIndex = 0;          // Índice do caminho atual

    void Start()
    {
        AtualizarObjetivo();  // Define o primeiro objetivo do inimigo
    }
    void Update()
    {
        MoverInimigo();
    }
    void MoverInimigo()
    {
        if (objetivo == null) return; // Se não há objetivo, não faz nada

        // Move em direção ao objetivo
        transform.position = Vector2.MoveTowards(
            transform.position,
            objetivo.position,
            velocidade * Time.deltaTime
        );

        // Verifica se o inimigo chegou ao ponto atual
        if (Vector2.Distance(transform.position, objetivo.position) <= 0.3f)
        {
            caminhoIndex++; // Avança para o próximo ponto

            // Se for o fim do caminho, destrói o inimigo
            if (caminhoIndex >= LevelManager.main.caminho.Length)
            {
                Destroy(gameObject);
            }
            else
            {
                AtualizarObjetivo(); // Atualiza para o próximo ponto
            }
        }
    }
    void VerificarFimDoCaminho()
    {
        // Se o índice ultrapassar o tamanho do caminho, destrói o inimigo
        if (caminhoIndex >= LevelManager.main.caminho.Length)
        {
            Destroy(gameObject);  // Destroi o inimigo
        }
    }

    void AtualizarObjetivo()
    {
        // Atualiza o objetivo com base no índice do caminho
        if (caminhoIndex < LevelManager.main.caminho.Length)
        {
            objetivo = LevelManager.main.caminho[caminhoIndex];
        }
        else
        {
            objetivo = null; // Define objetivo como nulo se ultrapassar o limite
        }
    }
    void InstanciarInimigos(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Vector3 posicaoSpawn = LevelManager.main.começo.position + new Vector3(i * separacao, 0, 0);
            GameObject novoInimigo = Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);

            // Configura o objetivo inicial para o inimigo instanciado
            InimigoPai inimigoScript = novoInimigo.GetComponent<InimigoPai>();
            inimigoScript.AtualizarObjetivo();  // Define o primeiro objetivo
        }
    }
}