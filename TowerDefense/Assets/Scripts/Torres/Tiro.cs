using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int dano = 10; // Dano inicial
    public int desaceleracao = 1; // Fator de desacelera��o
    public int duracaoDesaceleracao = 3; // Dura��o da desacelera��o
    private InimigoPai inimigoAlvo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            inimigoAlvo = other.GetComponent<InimigoPai>();
            if (inimigoAlvo != null)
            {
                // Aplica o dano inicial
                inimigoAlvo.ReceberDano(dano);

                // Inicia o dano cont�nuo, se necess�rio
               // StartCoroutine(DanoCont�nuo(inimigoAlvo));

                // Inicia a desacelera��o
                StartCoroutine(Desacelerar(inimigoAlvo));
            }
            Destroy(gameObject); // Destr�i a bala ap�s o impacto
        }
    }
    /*
    private IEnumerator DanoCont�nuo(InimigoPai inimigo)
    {
        float tempoDecorrido = 1f;
        int danoPorSegundo = 5; // Dano por segundo
        int duracaoDoDano = 5; // Dura��o do dano cont�nuo

        while (tempoDecorrido < duracaoDoDano && inimigo != null)
        {
           inimigo.ReceberDano(danoPorSegundo * Time.deltaTime);
            tempoDecorrido += Time.deltaTime;
            yield return null; // Espera at� o pr�ximo frame
           
        }
    }
     */
    private IEnumerator Desacelerar(InimigoPai inimigo)
    {
        float velocidadeOriginal = inimigo.velocidade;
        inimigo.velocidade *= desaceleracao; // Aplica a desacelera��o

        yield return new WaitForSeconds(duracaoDesaceleracao);

        // Restaura a velocidade original
        inimigo.velocidade = velocidadeOriginal;
    }
}
