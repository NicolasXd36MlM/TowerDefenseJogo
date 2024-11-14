using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float dano = 10f; // Dano inicial
    public float desaceleracao = 0.5f; // Fator de desaceleração
    public float duracaoDesaceleracao = 3f; // Duração da desaceleração
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

                // Inicia o dano contínuo, se necessário
                StartCoroutine(DanoContínuo(inimigoAlvo));

                // Inicia a desaceleração
                StartCoroutine(Desacelerar(inimigoAlvo));
            }
            Destroy(gameObject); // Destrói a bala após o impacto
        }
    }

    private IEnumerator DanoContínuo(InimigoPai inimigo)
    {
        float tempoDecorrido = 0f;
        float danoPorSegundo = 5f; // Dano por segundo
        float duracaoDoDano = 5f; // Duração do dano contínuo

        while (tempoDecorrido < duracaoDoDano && inimigo != null)
        {
            inimigo.ReceberDano(danoPorSegundo * Time.deltaTime);
            tempoDecorrido += Time.deltaTime;
            yield return null; // Espera até o próximo frame
        }
    }

    private IEnumerator Desacelerar(InimigoPai inimigo)
    {
        float velocidadeOriginal = inimigo.velocidade;
        inimigo.velocidade *= desaceleracao; // Aplica a desaceleração

        yield return new WaitForSeconds(duracaoDesaceleracao);

        // Restaura a velocidade original
        inimigo.velocidade = velocidadeOriginal;
    }
}
