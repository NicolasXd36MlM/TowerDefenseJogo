using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeInimigo : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] prefabInimigo;

    [SerializeField]
    private int BaseDoInimigo;
    [SerializeField]
    private float quantidadeDeInimgoPerSec = 0.5f;
    [SerializeField]
    private float intervaloDeTempo = 3f;
    [SerializeField]
    private float dificuldade = 0.60f;

    private int ondaAtual = 1;
    private float tempoDaUltimaOnda;
    private int inimigosVivos;
    private int inimigosEsperando;
    private bool nascendoIni = false;

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
            inimigosVivos++;
            tempoDaUltimaOnda = 0f;

        }
    }

    private void OndaInicial()
    {
        inimigosEsperando = EniPorOnda();
    }

    private void MensagemNasceu() 
    {
        Debug.Log("Nasceu!");
    }
    private int EniPorOnda() 
    {
        return Mathf.RoundToInt(BaseDoInimigo * Mathf.Pow(ondaAtual, dificuldade));
    
    }
}
