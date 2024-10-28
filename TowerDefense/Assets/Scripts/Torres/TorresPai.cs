using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public float alcance = 5f;
    public float velocidadeRotacao = 5f;
    private Transform alvo;

    void Update()
    {
        EncontrarAlvo();
        if (alvo != null)
        {
            RotacionarEmDirecaoAoAlvo();
        }
    }
    void EncontrarAlvo()
    {
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(transform.position, alcance);
        if (inimigos.Length > 0)
        {
            alvo = inimigos[0].transform; // Alvo será o primeiro inimigo detectado
        }
        else
        {
            alvo = null; // Nenhum alvo encontrado
        }
    }
     void RotacionarEmDirecaoAoAlvo()
    {
        Vector3 direction = alvo.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotacao = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacao, velocidadeRotacao * Time.deltaTime);
    }

    public class Arma : MonoBehaviour
    {
        public GameObject prefabBala; // Prefab da bala
        public Transform pontoDisparo; // Ponto de disparo

        void Atirar()
        {
            GameObject bala = Instantiate(prefabBala, pontoDisparo.position, pontoDisparo.rotation);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            rb.velocity = pontoDisparo.up * rb.GetComponent<Tiro>().velocidade; // Aplica a velocidade na direção do ponto de disparo

            // A rotação já deve estar correta ao instanciar a bala
            bala.transform.rotation = pontoDisparo.rotation;
        }
    }
}

