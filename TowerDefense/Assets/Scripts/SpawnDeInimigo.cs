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
    private int QuantiInimigo;
    [SerializeField]
    private float quantidadeDeInimgoPerSec;
    [SerializeField]
    private float intervaloDeTempo = 3f;
    [SerializeField]
    private float dificuldade = 0.75f;

<<<<<<< Updated upstream
    private readonly int ondaAtual = 1;
    private float tempoDaUltimaOnda;
    private int inimigosEsperando;
=======
    private readonly int ondaAtual;
    private float tempoDaUltimaOnda;
    private int inimigosVivos;
>>>>>>> Stashed changes
    private readonly bool nascendoIni = false;


    private void Update()
    {
        if (!nascendoIni) return;
        tempoDaUltimaOnda += Time.deltaTime;

        if (tempoDaUltimaOnda >= (1f / quantidadeDeInimgoPerSec) && inimigosVivos > 0)
        {
            MensagemNasceu();
<<<<<<< Updated upstream
            inimigosEsperando--;
=======
            inimigosVivos--;
>>>>>>> Stashed changes
            tempoDaUltimaOnda = 0f;
        }

    }
    private void Start()
    {
        OndaInicial();
        MensagemNasceu();
        EniPorOnda();
    }

    private void OndaInicial()
    {
        inimigosVivos = EniPorOnda();
    }
    private void MensagemNasceu() 
    {
<<<<<<< Updated upstream
        gameObject.GetComponent<InimigoPai>();
        Instantiate(PrefabInimigo, LevelManager.main.começo.eulerAngles,  Quaternion.identity);
        Debug.Log("Nasceu!!");
=======
        for (int i = 0; i < 10; i++)
        {
            gameObject.GetComponent<InimigoPai>();
            Instantiate(PrefabInimigo, LevelManager.main.começo.position, Quaternion.identity);
            Debug.Log("Nasceu!!");
            i++;
        }
       
>>>>>>> Stashed changes
    }
    private int EniPorOnda() //inimigos por onda
    {
        return Mathf.RoundToInt(QuantiInimigo * Mathf.Pow(ondaAtual, dificuldade));
    
    }
}