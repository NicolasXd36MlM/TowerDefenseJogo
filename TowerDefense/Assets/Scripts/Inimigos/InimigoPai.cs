using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{ 
    [SerializeField] private Rigidbody2D corpo;
    [SerializeField] private float velocidade = 1f;

    private Transform objetivo;


    [SerializeField] private int caminhoIndex = 0;

    
    private void Start() // define o final
    {
            objetivo = LevelManager.main.caminhos[caminhoIndex]; //define o caminho para o final final
    }
    void Update() //vai definir o final final
    {
            if (Vector2.Distance(objetivo.position, transform.position) <= 0.1f) //checar se a distancia do final esta na posição igual ou menor que 0.3
            {
                caminhoIndex++; //  vai aumentar em 1 a distancia do final
                if (caminhoIndex >= LevelManager.main.caminhos.Length) // se o caminho foi menor ou igual o "final" 
                {
                    Destroy(gameObject); //destroi o inimigo
                    return; //cria uma nova possibilidade
                }
                else
                {
                    objetivo = LevelManager.main.caminhos[caminhoIndex];

                }
            }
        CorrigirCaminho();
    }
    private void CorrigirCaminho() // vai manter o inimigo no caminho certo e manter ele em direção ao final
    {
        Vector2 direcao = (objetivo.position - transform.position).normalized;
        corpo.velocity = direcao * velocidade; //define que o corpo vai se mover para a proxima possição marcada
    }
}
