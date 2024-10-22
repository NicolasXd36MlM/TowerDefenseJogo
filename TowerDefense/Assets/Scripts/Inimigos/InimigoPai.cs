using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D corpo;
    [SerializeField] private float velocidade = 5f;

    private Transform objetivo;
    private int caminhoIndex = 18;
    // Start is called before the first frame update
    void Start()
    {
        // Verifica se o LevelManager e Caminhos estão corretamente configurados
        if (LevelManager.main != null && LevelManager.main.Caminhos != null && LevelManager.main.Caminhos.Length > 0)
        {
            objetivo = LevelManager.main.Caminhos[caminhoIndex]; // Define o objetivo inicial
        }
        /*
        else
        {
            Debug.LogError("LevelManager ou Caminhos não foram inicializados corretamente.");
            Destroy(gameObject); // Destroi o inimigo para evitar problemas futuros
        } */
    }

    // Update is called once per frame
    void Update() //vai definir o objetivo final
    {
        Debug.LogError("Problema com o update");
        if (Vector2.Distance(objetivo.position, transform.position) <= 0.3f) //checar se a distancia do objetivo esta na posição igual ou menor que 0.3
        {
            caminhoIndex++; //  vai aumentar em 1 a distancia do objetivo
            Debug.LogError("Problema com o If");

            if (caminhoIndex >= LevelManager.main.Caminhos.Length) // se o caminho foi menor ou igual o "final" 
            {
            Destroy(gameObject); //destroi o inimigo
            return; //cria um novo inimigo
            }
            else 
            {
                objetivo = LevelManager.main.Caminhos[caminhoIndex];

            }
        }
    }
    private void CorrigirCaminho() // vai manter o inimigo no caminho certo e manter ele em direção ao objetivo
    {
        Vector2 direcao = (objetivo.position = transform.position).normalized;
    
        corpo.velocity = direcao * velocidade; //define que o corpo vai se mover para a proxima possição marcada
    }
}
