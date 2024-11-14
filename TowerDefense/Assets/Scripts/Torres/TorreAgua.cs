using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class TorreAgua : TorresPai
=======
public class TorreAgua : TorrePai
>>>>>>> Stashed changes
{
    public void Atirar()
    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
        {
            GameObject bala = Instantiate(balaPrefab, pontoDisparo.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            Vector2 direcao = (alvoAtual.position - transform.position).normalized;
            rb.velocity = direcao * 10f;

            // Passa os par�metros de desacelera��o
            Tiro balaScript = bala.GetComponent<Tiro>();
            if (balaScript != null)
            {
                balaScript.desaceleracao = 2; // ou outro valor que voc� quiser
                balaScript.duracaoDesaceleracao = 3; // ou outro valor que voc� quiser
            }

            tempoRestanteParaAtirar = tempoEntreTiros;
        }
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }
    }
}