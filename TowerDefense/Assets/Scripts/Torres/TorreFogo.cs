using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreFogo : TorrePai
{
    public float danoPorSegundo = 5f; // Dano por segundo
    public float duracaoDoDano = 5f; // Duração do dano contínuo


    public override void Atirar()
    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
        {
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            Vector2 direcao = (alvoAtual.position - transform.position).normalized;
            rb.velocity = direcao * 10f;

            // Passa os parâmetros de dano, se necessário
            Tiro balaScript = bala.GetComponent<Tiro>();
            if (balaScript != null)
            {
                balaScript.dano = 10; // ou outro valor que você quiser
            }

            tempoRestanteParaAtirar = tempoEntreTiros;
        }
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }

    }
}