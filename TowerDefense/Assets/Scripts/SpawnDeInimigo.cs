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
    private int QuantiInimigo = 8;
    [SerializeField]
    private float quantidadeDeInimgoPerSec = 0.5f;
    //[SerializeField]
    //private float intervaloDeTempo = 3f;
    [SerializeField]
    private float dificuldade = 0.60f;

    private readonly int ondaAtual = 1;
    private float tempoDaUltimaOnda;
    private int inimigosEsperando;
    private readonly bool nascendoIni = false;

    private void Start()
    {
        OndaInicial();
    }

    private void Update()
    {
        if (!nascendoIni) return; 
        tempoDaUltimaOnda += Time.deltaTime;

        if (tempoDaUltimaOnda >= (1f / quantidadeDeInimgoPerSec) && inimigosEsperando > 0)
        {
            MensagemNasceu();
            inimigosEsperando--;
            tempoDaUltimaOnda = 0f;
            
        }

    }

    private void OndaInicial()
    {
        inimigosEsperando = EniPorOnda();
    }

    private void MensagemNasceu() 
    {
        gameObject.GetComponent<InimigoPai>();
        Instantiate(PrefabInimigo, LevelManager.main.começo.eulerAngles,  Quaternion.identity);
        Debug.Log("Nasceu!!");
    }
    private int EniPorOnda() 
    {
        return Mathf.RoundToInt(QuantiInimigo * Mathf.Pow(ondaAtual, dificuldade));
    
    }
}
