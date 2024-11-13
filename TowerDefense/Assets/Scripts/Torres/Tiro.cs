using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
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
        {
            InimigoPai inimigo = colisao.gameObject.GetComponent<InimigoPai>();
            if (inimigo != null)
            {
                inimigo.ReceberDano(10); // Causa dano ao inimigo
            }
            Destroy(gameObject); // Destr�i a bala ap�s a colis�o
        }
    }
}
