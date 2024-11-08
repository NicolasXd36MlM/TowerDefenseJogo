using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 10f; // Velocidade da bala

    void Start()
    {
        // A bala j� deve estar rotacionada corretamente ao ser instanciada
    }

    void Update()
    {
        // Aqui voc� pode adicionar l�gica para a movimenta��o da bala, se necess�rio
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
