using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAgua : TorrePai
{
    public override void Atirar()
    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
        {
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            Vector2 direcao = (alvoAtual.position - transform.position).normalized;
            rb.velocity = direcao * 10f;

            // Passa os parâmetros de desaceleração
            Tiro balaScript = bala.GetComponent<Tiro>();
            if (balaScript != null)
            {
                balaScript.desaceleracao = 2; // ou outro valor que você quiser
                balaScript.duracaoDesaceleracao = 3; // ou outro valor que você quiser
            }

            tempoRestanteParaAtirar = tempoEntreTiros;
        }
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }
    }
}