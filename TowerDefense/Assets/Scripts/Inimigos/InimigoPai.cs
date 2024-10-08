using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Atributos")]
    [SerializeField] private float velocidade = 1f;

    private Transform objetivo;
    private int caminhoIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = LevelManager.main.caminhos[caminhoIndex]; //define o caminho para o objetivo final
    }

    // Update is called once per frame
    void Update() //vai definir o objetivo final
    {
        if (Vector2.Distance(objetivo.position, transform.position) <= 0.1f) //checar se a distancia do objetivo esta na posição igual ou menor que 0.3
        {
            caminhoIndex++; //  vai aumentar em 1 a distancia do objetivo
            

            if (caminhoIndex >= LevelManager.main.caminhos.Length) // se o caminho foi menor ou igual o "final" 
            {
            Destroy(gameObject); //destroi o inimigo
            return; //cria um novo inimigo
            }
            else 
            {
                objetivo = LevelManager.main.caminhos[caminhoIndex];

            }
        }
    }
    private void CorrigirCaminho() // vai manter o inimigo no caminho certo e manter ele em direção ao objetivo
    {
        Vector2 direcao = (objetivo.position = transform.position).normalized;
    
        corpo.velocity = direcao * velocidade; //define que o corpo vai se mover para a proxima possição marcada
    }
}
