using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D corpo;
    [SerializeField] private float velocidade = 5f;

    private Transform final;
    private int caminhoIndex = 20;
    // Start is called before the first frame update
    void Start()
    {
        final = LevelManager.main.Caminhos[caminhoIndex]; // Define o final inicial
    }
    // Update is called once per frame
    void Update() //vai definir o final
    {
        if (Vector2.Distance(final.position, transform.position) <= 0.3f) //checar se a distancia do final esta na posição igual ou menor que 0.3 / Verifica se o LevelManager e Caminhos estão corretamente configurados

        {
            caminhoIndex++; //  vai aumentar em 1 a distancia do final

            if (caminhoIndex == LevelManager.main.Caminhos.Length) // se o caminho foi menor ou igual o "final" 
            {
            Destroy(gameObject); //destroi o inimigo
            return; //cria um novo inimigo
            }
            else 
            {
                final = LevelManager.main.Caminhos[caminhoIndex];
            }
        }
    }
    private void CorrigirCaminho() // vai manter o inimigo no caminho certo e manter ele em direção ao final
    {
        Vector2 direcao = (final.position = transform.position).normalized ;
    
        corpo.velocity = direcao * velocidade; //define que o corpo vai se mover para a proxima possição marcada
    }
}
