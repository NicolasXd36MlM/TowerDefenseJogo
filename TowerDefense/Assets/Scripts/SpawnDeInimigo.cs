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
    /*[SerializeField]
    private float intervaloDeTempo = 3f;*/
    [SerializeField]
    private float dificuldade = 0.75f;

    private readonly int ondaAtual = 1;
    private float tempoDaUltimaOnda;
    private int inimigosEsperando;
    private int inimigosVivos;
    private readonly bool nascendoIni = false;


    private void Update()
    {
        if (!nascendoIni) return;
        tempoDaUltimaOnda += Time.deltaTime;

        if (tempoDaUltimaOnda >= (1f / quantidadeDeInimgoPerSec) && inimigosVivos > 0)
        {
            MensagemNasceu();
            inimigosEsperando--;
            inimigosVivos--;
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
        for (int i = 0; i < 10; i++)
        {
            gameObject.GetComponent<InimigoPai>();
            Instantiate(PrefabInimigo, LevelManager.main.começo.position, Quaternion.identity);
            Debug.Log("Nasceu!!");
            i++;
        }
       
    }
    private int EniPorOnda() //inimigos por onda
    {
        return Mathf.RoundToInt(QuantiInimigo * Mathf.Pow(ondaAtual, dificuldade));
    
    }
}