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
        // A bala já deve estar rotacionada corretamente ao ser instanciada
    }

    void Update()
    {
        GameObject bullet = Instantiate(balinha, pontoDeDisparo.position, pontoDeDisparo.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = pontoDeDisparo.up * bullet.GetComponent<bala>().velocidadeDaBala; // Aplica a velocidade na direção do firePoint

        // Rotaciona a bala para a direção do disparo
        bullet.transform.rotation = pontoDeDisparo.rotation;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Inimigo"))
=======
    public int dano = 10; // Dano inicial
    public int desaceleracao = 2; // Fator de desaceleração
    public int duracaoDesaceleracao = 3; // Duração da desaceleração
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
