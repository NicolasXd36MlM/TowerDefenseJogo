using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidadeDaBala = 10f; // Velocidade da bala
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * velocidadeDaBala; // Define a velocidade da bala
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Lógica para causar dano ao inimigo
            InimigoPai inimigo = collision.gameObject.GetComponent<InimigoPai>();
            if (inimigo != null)
            {
                inimigo.ReceberDano(5); // Exemplo de dano
            }
            Destroy(gameObject); // Destrói a bala após a colisão
        }
    }
}