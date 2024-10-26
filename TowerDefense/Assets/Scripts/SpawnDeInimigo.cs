using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class SpawnDeInimigo : MonoBehaviour
{
    [SerializeField]
    private GameObject PrefabInimigo;

    [SerializeField]
    private int QuantiInimigo = 10; // Quantidade total de inimigos por onda
    [SerializeField]
<<<<<<< Updated upstream
    private float quantidadeDeInimgoPerSec;
    [SerializeField]
    private float intervaloDeTempo = 3f;
    [SerializeField]
    private float dificuldade = 0.75f;


    private readonly int ondaAtual = 1;
    private float tempoDaUltimaOnda;
    private int inimigosEsperando;
    private int inimigosVivos;

    private readonly bool nascendoIni = false;
=======
    private float quantidadeDeInimgoPerSec = 1f; // Inimigos por segundo
    [SerializeField]
    private float dificuldade = 0.75f;

    private int ondaAtual = 1; // Número da onda atual
    private float tempoDaUltimaOnda = 0f; // Tempo desde o último spawn
    private int inimigosEsperando; // Inimigos que ainda não foram spawnados
    private int inimigosVivos; // Inimigos que ainda estão ativos
    private bool nascendoIni = false; // Controle do spawn
>>>>>>> Stashed changes

    private void Start()
    {
        OndaInicial(); // Inicializa a primeira onda
        nascendoIni = true; // Ativa o spawn
    }

    private void Update()
    {
        if (!nascendoIni) return; // Se o spawn não estiver ativo, sai

        tempoDaUltimaOnda += Time.deltaTime; // Atualiza o tempo

        // Se for hora de spawnar e ainda houver inimigos esperando
        if (tempoDaUltimaOnda >= (1f / quantidadeDeInimgoPerSec) && inimigosEsperando > 0)
        {
            SpawnInimigo(); // Chama o método para spawnar um inimigo
            inimigosEsperando--; // Decrementa o número de inimigos que ainda precisam nascer
            tempoDaUltimaOnda = 0f; // Reseta o tempo para o próximo spawn
        }

        // Se todos os inimigos da onda foram eliminados, inicia a próxima onda
        if (inimigosVivos <= 0 && inimigosEsperando <= 0)
        {
            IniciarProximaOnda();
        }
    }

    private void OndaInicial()
    {
        inimigosEsperando = EniPorOnda(); // Define quantos inimigos serão spawnados nesta onda
        inimigosVivos = inimigosEsperando; // Inicializa os inimigos vivos
    }

    private void SpawnInimigo()
    {
<<<<<<< Updated upstream

        gameObject.GetComponent<InimigoPai>();
        Instantiate(PrefabInimigo, LevelManager.main.começo.eulerAngles,  Quaternion.identity);
        Debug.Log("Nasceu!!");

        for (int i = 0; i < 10; i++)
=======
        if (LevelManager.main == null || LevelManager.main.começo == null)
>>>>>>> Stashed changes
        {
            Debug.LogError("LevelManager ou ponto de início não estão configurados.");
            return; // Sai se não estiver configurado corretamente
        }

<<<<<<< Updated upstream
=======
        // Instancia o inimigo na posição do ponto inicial
        Instantiate(PrefabInimigo, LevelManager.main.começo.position, Quaternion.identity);
        inimigosVivos++; // Incrementa o número de inimigos vivos
        Debug.Log("Inimigo Spawnado! Total Vivos: " + inimigosVivos);
>>>>>>> Stashed changes
    }

    private int EniPorOnda()
    {
        // Calcula o número de inimigos para a onda atual
        return Mathf.RoundToInt(QuantiInimigo * Mathf.Pow(ondaAtual, dificuldade));
    }

    private void IniciarProximaOnda()
    {
        ondaAtual++; // Incrementa o número da onda
        OndaInicial(); // Prepara a nova onda
        Debug.Log($"Iniciando Onda {ondaAtual} com {inimigosEsperando} inimigos.");
    }
}