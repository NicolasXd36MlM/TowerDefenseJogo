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

    private void Update()
    {
        if (!nascendoIni) return; 
        tempoDaUltimaOnda += Time.deltaTime;

        if (tempoDaUltimaOnda >= (1f / quantidadeDeInimgoPerSec))
            Debug.Log("Nasceu!");
        {
        
        
        }
    }

    private void OndaInicial()
    {
        inimigosEsperando = EniPorOnda();
    }

    private int EniPorOnda() 
    {
        return Mathf.RoundToInt(BaseDoInimigo * Mathf.Pow(ondaAtual, dificuldade));
    
    }
}
