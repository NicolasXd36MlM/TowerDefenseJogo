using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrePai : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab da bala
    public Transform pontoDisparo; // Local de disparo
    public float alcance = 5f; // Alcance da torreta
    public float tempoEntreTiros = 1f; // Intervalo entre disparos
    public LayerMask camadaInimigos; // Máscara para detectar inimigos

    public Transform alvoAtual;
    public float tempoRestanteParaAtirar;

    void Update()
    {
        ProcurarAlvo();
        if (alvoAtual != null)
        {
            RotacionarParaAlvo();
            Atirar();
            
        }
        Atirar();
    }

    void ProcurarAlvo()
    {
        Collider2D[] inimigosNaArea = Physics2D.OverlapCircleAll(transform.position, alcance, camadaInimigos);

        if (inimigosNaArea.Length > 0)
        {
            alvoAtual = inimigosNaArea[0].transform; // Seleciona o primeiro inimigo detectado
        }
        else
        {
            alvoAtual = null;
        }
    }

    void RotacionarParaAlvo()
    {
        Vector2 direcao = (alvoAtual.position - transform.position).normalized;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo - 90);
    }
      public virtual void  Atirar()

    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
        {
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity); // Usando a posição do inimigo
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            Vector2 direcao = (alvoAtual.position - transform.position).normalized;
            rb.velocity = direcao * 10f; // Define a velocidade da bala
            tempoRestanteParaAtirar = tempoEntreTiros;
        }
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a área de alcance no editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}
