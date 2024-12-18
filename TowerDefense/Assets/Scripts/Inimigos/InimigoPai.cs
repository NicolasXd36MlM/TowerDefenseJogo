using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    public float separacao = 2f;          // Dist�ncia entre inimigos
    public GameObject prefabInimigo;       // Prefab do inimigo
    public float velocidade = 5f;          // Velocidade do inimigo
    private Transform objetivo;             // Ponto de destino
    private int caminhoIndex = 20;          // �ndice do caminho atual
    [SerializeField]
    protected int vida;
    [SerializeField]
    LayerMask inimigo;

    void Start()
    {
        AtualizarObjetivo();  // Define o primeiro objetivo do inimigo
        LayerMask.NameToLayer(inimigo.ToString());
    }
    void Update()
    {
        MoverInimigo();
        VerificarFimDoCaminho();
    }
    public void MoverInimigo()
    {
        if (objetivo == null) return; // Se n�o h� objetivo, n�o faz nada

        // Move em dire��o ao objetivo
        transform.position = Vector2.MoveTowards(
            transform.position,
            objetivo.position,
            velocidade * Time.deltaTime
        );

        // Verifica se o inimigo chegou ao ponto atual
        if (Vector2.Distance(transform.position, objetivo.position) <= 0.3f)
        {
            caminhoIndex++; // Avan�a para o pr�ximo ponto

            // Se for o fim do caminho, destr�i o inimigo
            if (caminhoIndex >= LevelManager.main.caminho.Length)
            {
                Destroy(gameObject);
            }
            else
            {
                AtualizarObjetivo(); // Atualiza para o pr�ximo ponto
            }
        }
    }
    public virtual void VerificarFimDoCaminho()
    {
        // Se o �ndice ultrapassar o tamanho do caminho, destr�i o inimigo
        if (caminhoIndex >= LevelManager.main.caminho.Length)
        {
            Destroy(gameObject);  // Destroi o inimigo
        }
    }

    public virtual void AtualizarObjetivo()
    {
        // Verifica se a inst�ncia do LevelManager est� inicializada
        if (LevelManager.main == null)
        {
            Debug.LogError("LevelManager.main � null!");
            return; // Saia do m�todo se for null
        }

        // Verifica se o caminho � null
        if (LevelManager.main.caminho == null)
        {
            Debug.LogError("caminho � null!");
            return; // Saia do m�todo se for null
        }

        // Atualiza o objetivo com base no �ndice do caminho
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
            Vector3 posicaoSpawn = LevelManager.main.pontoDeSpawn.position + new Vector3(i * separacao, 0, 0);
            GameObject novoInimigo = Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);

            // Configura o objetivo inicial para o inimigo instanciado
            InimigoPai inimigoScript = novoInimigo.GetComponent<InimigoPai>();
            inimigoScript.AtualizarObjetivo();  // Define o primeiro objetivo
        }
    }

    public virtual void ReceberDano(int dano)
    {
        vida -= dano; // Subtrai a vida do inimigo

        if (vida <= 0)
        {
            Destroy(gameObject); // Destr�i o inimigo se a vida chegar a 0
        }
    }

    internal void ReceberDano(float v)
    {
        throw new NotImplementedException();
    }
}