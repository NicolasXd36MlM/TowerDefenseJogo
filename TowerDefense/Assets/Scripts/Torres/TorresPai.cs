using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrePai : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab da bala
    public Transform pontoDisparo; // Local de disparo
    public float alcance = 5f; // Alcance da torreta
    public float tempoEntreTiros = 1f; // Intervalo entre disparos
    public LayerMask camadaInimigos; // M�scara para detectar inimigos

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

<<<<<<< Updated upstream
        public GameObject prefabBala; // Prefab da bala
        public Transform pontoDisparo; // Ponto de disparo

        void Atirar()
=======
    void Atirar()
    {
        if (tempoRestanteParaAtirar <= 0f && alvoAtual != null)
>>>>>>> Stashed changes
        {
            GameObject bala = Instantiate(balaPrefab, alvoAtual.position, Quaternion.identity); // Usando a posi��o do inimigo
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            Vector2 direcao = (alvoAtual.position - transform.position).normalized;
            rb.velocity = direcao * 10f; // Define a velocidade da bala
            tempoRestanteParaAtirar = tempoEntreTiros;
        }
<<<<<<< Updated upstream
    
=======
        else
        {
            tempoRestanteParaAtirar -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a �rea de alcance no editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
>>>>>>> Stashed changes
}
