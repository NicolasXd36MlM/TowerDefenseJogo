using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
<<<<<<< Updated upstream
    public float velocidade = 10f; // Velocidade da bala
    public GameObject balinha; // Prefab da bala
    public Transform pontoDeDisparo; // Ponto de disparo
    void Start()
    {
        // A bala j� deve estar rotacionada corretamente ao ser instanciada
    }

    void Update()
    {
        GameObject bullet = Instantiate(balinha, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = pontoDeDisparo.up * bullet.GetComponent<bala>().velocidadeDaBala; // Aplica a velocidade na dire��o do firePoint

        // Rotaciona a bala para a dire��o do disparo
        bullet.transform.rotation = pontoDeDisparo.rotation;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Inimigo"))
=======
    public int dano = 10; // Dano inicial
    public int desaceleracao = 2; // Fator de desacelera��o
    public int duracaoDesaceleracao = 3; // Dura��o da desacelera��o
    private InimigoPai inimigoAlvo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
>>>>>>> Stashed changes
        {
            inimigoAlvo = other.GetComponent<InimigoPai>();
            if (inimigoAlvo != null)
            {
                // Aplica o dano inicial
                inimigoAlvo.ReceberDano(dano);

                // Inicia o dano cont�nuo, se necess�rio
                StartCoroutine(DanoCont�nuo(inimigoAlvo));

                // Inicia a desacelera��o
                StartCoroutine(Desacelerar(inimigoAlvo));
            }
            Destroy(gameObject); // Destr�i a bala ap�s o impacto
        }
    }

    private IEnumerator DanoCont�nuo(InimigoPai inimigo)
    {
        float tempoDecorrido = 0f;
        float danoPorSegundo = 5f; // Dano por segundo
        float duracaoDoDano = 5f; // Dura��o do dano cont�nuo

        while (tempoDecorrido < duracaoDoDano && inimigo != null)
        {
            inimigo.ReceberDano(danoPorSegundo * Time.deltaTime);
            tempoDecorrido += Time.deltaTime;
            yield return null; // Espera at� o pr�ximo frame
        }
    }

    private IEnumerator Desacelerar(InimigoPai inimigo)
    {
        float velocidadeOriginal = inimigo.velocidade;
        inimigo.velocidade *= desaceleracao; // Aplica a desacelera��o

        yield return new WaitForSeconds(duracaoDesaceleracao);

        // Restaura a velocidade original
        inimigo.velocidade = velocidadeOriginal;
    }
}
