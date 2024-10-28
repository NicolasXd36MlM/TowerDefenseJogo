using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 10f; // Velocidade da bala

    void Start()
    {
        // A bala já deve estar rotacionada corretamente ao ser instanciada
    }

    void Update()
    {
        // Aqui você pode adicionar lógica para a movimentação da bala, se necessário
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
            Destroy(gameObject); // Destrói a bala após a colisão
        }
    }
}
