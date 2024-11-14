using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TorreRaio : TorrePai
{
    public int raioDeEfeito = 5; // Raio em que os inimigos serão afetados
    public int dano = 20; // Dano causado
    public int duracaoAtordoamento = 2; // Duração do atordoamento
    public int numeroDeDisparos = 3; // Número de raios disparados (definido como int)
    public float intervaloEntreDisparos = 0.2f; // Intervalo entre os disparos

    void Atirar()
    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
        {
            StartCoroutine(DispararRaios());
            tempoRestanteParaAtirar = tempoEntreTiros; // Reseta o tempo de recarga
        }
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }
    }

    private IEnumerator DispararRaios()
    {
        // Encontra todos os inimigos dentro do raio de efeito
        Collider2D[] inimigosNoRaio = Physics2D.OverlapCircleAll(transform.position, raioDeEfeito, LayerMask.GetMask("Inimigo"));

        for (int i = 0; i < numeroDeDisparos; i++)
        {
            foreach (var inimigoCollider in inimigosNoRaio)
            {
                InimigoPai inimigo = inimigoCollider.GetComponent<InimigoPai>();
                if (inimigo != null)
                {
                    // Aplica dano
                    inimigo.ReceberDano(dano);
                }
            }

            yield return new WaitForSeconds(intervaloEntreDisparos); // Espera entre os disparos
        }
    }
}